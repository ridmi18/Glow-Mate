using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class UserProduct : Form
    {
        public UserProduct()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadProductsWithCategory();

            // Auto-select first row if available
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                ShowRowDetails(dataGridView1.Rows[0]);
            }

            // Update when selection changes
            dataGridView1.SelectionChanged += (s, ev) =>
            {
                if (dataGridView1.CurrentRow != null)
                {
                    ShowRowDetails(dataGridView1.CurrentRow);
                }
            };
        }

        private void LoadProductsWithCategory()
        {
            try
            {
                DatabaseConnector db = new DatabaseConnector();
                string query = @"
                    SELECT 
                        p.ProductName,
                        p.CategoryId AS [Category ID],
                        p.ManufacturedDate AS [Manufactured Date],
                        p.ExpiryDate AS [Expiry Date],
                        p.Status,
                        p.ProductDetails AS [Product Details],
                        p.Image
                    FROM Products p";

                DataTable dt = db.ExecuteQuery(query);

                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;

                // Hide details & image columns in grid
                if (dataGridView1.Columns.Contains("Product Details"))
                    dataGridView1.Columns["Product Details"].Visible = false;
                if (dataGridView1.Columns.Contains("Image"))
                    dataGridView1.Columns["Image"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void ShowRowDetails(DataGridViewRow row)
        {
            if (row == null) return;

            // Display only the actual product details, without "Product Details:" prefix
            label1.Text = row.Cells["Product Details"]?.Value?.ToString();

            // Show product image if available
            if (row.Cells["Image"].Value != DBNull.Value && row.Cells["Image"].Value is byte[] imageData)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowRowDetails(dataGridView1.Rows[e.RowIndex]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: could trigger edit or show a bigger details window
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // Optional: could open full image view
        }

        private void button1_Click(object sender, EventArgs e) // Logout
        {
            var loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) // Feedback
        {
            var feedbackForm = new UserFeedback();
            feedbackForm.Show();
        }
    }
}
