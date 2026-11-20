using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class ProductPage : Form
    {
        private string imagePath = string.Empty;
        private bool imageUploaded = false;
        private int? updateProductId = null;
        private byte[] existingImage = null;

        // Error provider for the red warning icon
        private readonly ErrorProvider _err = new ErrorProvider();

        // Default constructor for Add mode
        public ProductPage()
        {
            InitializeComponent();

            // Configure error provider (must point at this form)
            _err.ContainerControl = this;
            _err.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _err.SetIconAlignment(textBox3, ErrorIconAlignment.MiddleRight);
            _err.SetIconPadding(textBox3, 2);

            // Restrict typing in Quantity to digits only
            textBox3.KeyPress -= Quantity_KeyPress_DigitsOnly;
            textBox3.KeyPress += Quantity_KeyPress_DigitsOnly;
        }

        // Overloaded constructor for Update mode
        public ProductPage(DataRow row) : this()
        {
            updateProductId = Convert.ToInt32(row["ProductId"]);
            textBox1.Text = row["ProductName"].ToString();
            comboBox1.SelectedItem = row["Category Name"].ToString();
            textBox3.Text = row["Quantity"].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row["Manufactured Date"]);
            dateTimePicker2.Value = Convert.ToDateTime(row["Expiry Date"]);
            textBox5.Text = row["Status"].ToString();
            textBox6.Text = row["Product Details"].ToString();

            if (row["Image"] != DBNull.Value)
            {
                existingImage = (byte[])row["Image"];
                using (MemoryStream ms = new MemoryStream(existingImage))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[]
            {
                "Skincare", "Makeup", "Haircare", "Bodycare", "Nailcare", "Fragrance"
            });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;

                    if (!File.Exists(imagePath))
                    {
                        MessageBox.Show("Selected image file does not exist.", "Image Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageUploaded = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate quantity again before saving
            if (!ValidateQuantity())
            {
                textBox3.Focus();
                return;
            }

            string name = textBox1.Text.Trim();
            string categoryName = comboBox1.SelectedItem?.ToString();
            DateTime manufacturedDate = dateTimePicker1.Value;
            DateTime expiryDate = dateTimePicker2.Value;
            string status = textBox5.Text.Trim();
            string details = textBox6.Text.Trim();
            int quantity = int.TryParse(textBox3.Text.Trim(), out int q) ? q : 0;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(categoryName) ||
                quantity <= 0 || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(details))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? categoryId = GetCategoryIdByName(categoryName);
            if (categoryId == null)
            {
                MessageBox.Show("Category not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imageBytes = null;
            if (imageUploaded && !string.IsNullOrEmpty(imagePath))
            {
                imageBytes = File.ReadAllBytes(imagePath);
            }

            DatabaseConnector db = new DatabaseConnector();

            if (updateProductId.HasValue)
            {
                // UPDATE operation
                string updateQuery = @"UPDATE Products SET 
                    ProductName = @ProductName,
                    CategoryId = @CategoryId,
                    ManufacturedDate = @ManufacturedDate,
                    ExpiryDate = @ExpiryDate,
                    Quantity = @Quantity,
                    Status = @Status,
                    ProductDetails = @ProductDetails"
                    + (imageBytes != null ? ", Image = @Image" : "") +
                    " WHERE ProductId = @ProductId";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ProductName", name),
                    new SqlParameter("@CategoryId", categoryId),
                    new SqlParameter("@ManufacturedDate", manufacturedDate),
                    new SqlParameter("@ExpiryDate", expiryDate),
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@ProductDetails", details),
                    new SqlParameter("@ProductId", updateProductId)
                };

                if (imageBytes != null)
                    parameters.Add(new SqlParameter("@Image", imageBytes));

                int rows = db.ExecuteNonQuery(updateQuery, parameters.ToArray());
                MessageBox.Show(rows > 0 ? "Product updated successfully." : "Product update failed.");
            }
            else
            {
                // INSERT operation
                if (!imageUploaded || string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show("Please upload an image for the product.");
                    return;
                }

                imageBytes = File.ReadAllBytes(imagePath);

                string insertQuery = @"INSERT INTO Products 
                    (ProductName, CategoryId, ManufacturedDate, ExpiryDate, Quantity, Status, ProductDetails, Image) 
                    VALUES 
                    (@ProductName, @CategoryId, @ManufacturedDate, @ExpiryDate, @Quantity, @Status, @ProductDetails, @Image)";

                SqlParameter[] parameters = {
                    new SqlParameter("@ProductName", name),
                    new SqlParameter("@CategoryId", categoryId),
                    new SqlParameter("@ManufacturedDate", manufacturedDate),
                    new SqlParameter("@ExpiryDate", expiryDate),
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@ProductDetails", details),
                    new SqlParameter("@Image", imageBytes)
                };

                int result = db.ExecuteNonQuery(insertQuery, parameters);
                MessageBox.Show(result > 0 ? "Product added successfully." : "Failed to add product.");
            }

            var form4 = new ProductManagement();
            form4.Show();
            this.Hide();
        }

        private int? GetCategoryIdByName(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return null;

            DatabaseConnector db = new DatabaseConnector();
            const string query = "SELECT CategoryId FROM Categories WHERE CategoryName = @CategoryName";

            SqlParameter[] parameters = { new SqlParameter("@CategoryName", categoryName) };

            object result = db.ExecuteScalar(query, parameters);
            return result != null && int.TryParse(result.ToString(), out int id) ? id : (int?)null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form4 = new ProductManagement();
            form4.Show();
            this.Hide();
        }

        // -------------------------
        // Quantity validation bits
        // -------------------------

        // Live validation -> shows/hides the warning icon
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            ValidateQuantity();
        }

        private bool ValidateQuantity()
        {
            string txt = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(txt))
            {
                _err.SetError(textBox3, "Quantity is required.");
                return false;
            }

            // Positive integer only (no 0, no negatives)
            if (!int.TryParse(txt, out int qty) || qty <= 0)
            {
                _err.SetError(textBox3, "Enter a valid positive number (e.g., 1, 2, 3…).");
                return false;
            }

            _err.SetError(textBox3, string.Empty); // clear icon
            return true;
        }

        private void Quantity_KeyPress_DigitsOnly(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, arrows, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Block anything that isn't a digit
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Optional event handlers you already had
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void textBox2_TextChanged_1(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
    }
}
