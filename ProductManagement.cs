using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class ProductManagement : Form
    {
        // Keep the full, unfiltered set here
        private DataTable _allProducts;

        public ProductManagement()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadProductsWithCategory();
        }

        private void LoadProductsWithCategory()
        {
            try
            {
                var db = new DatabaseConnector();
                string query = @"
                    SELECT 
                        p.ProductId,
                        p.ProductName,
                        c.CategoryName AS [Category Name],
                        p.Quantity,
                        p.ManufacturedDate AS [Manufactured Date],
                        p.ExpiryDate     AS [Expiry Date],
                        p.Status,
                        p.ProductDetails AS [Product Details],
                        p.Image
                    FROM dbo.Products p
                    JOIN dbo.Categories c ON p.CategoryId = c.CategoryId;";

                _allProducts = db.ExecuteQuery(query);

                BindGrid(_allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void BindGrid(DataTable dt)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = dt;

            if (dataGridView2.Columns.Contains("Product Details"))
                dataGridView2.Columns["Product Details"].Visible = false;

            if (dataGridView2.Columns.Contains("Image"))
                dataGridView2.Columns["Image"].Visible = false;

            // Auto-select first row so the details/image show immediately
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.ClearSelection();
                dataGridView2.Rows[0].Selected = true;
                // trigger the details/image fill
                dataGridView2_CellClick(this,
                    new DataGridViewCellEventArgs(0, 0));
            }
            else
            {
                textBox1.Clear();
                pictureBox1.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProductPage().Show(); // Add Mode
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                if (dataGridView2.CurrentRow.DataBoundItem is DataRowView drv)
                {
                    var editForm = new ProductPage(drv.Row); // Update Mode
                    editForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid selection.");
                }
            }
            else
            {
                MessageBox.Show("Select a row to update.");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new AdminDashboard().Show();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView2.Rows.Count == 0) return;

            var row = dataGridView2.Rows[e.RowIndex];

            textBox1.Text = row.Cells["Product Details"]?.Value?.ToString();

            if (row.Cells["Image"].Value != DBNull.Value)
            {
                try
                {
                    byte[] imageData = (byte[])row.Cells["Image"].Value;
                    using (var ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Failed to load image.");
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // (unused)
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            object value = dataGridView2.CurrentRow.Cells["ProductId"].Value;
            object nameValue = dataGridView2.CurrentRow.Cells["ProductName"].Value;

            if (value == null || value == DBNull.Value)
            {
                MessageBox.Show("Invalid row selected.");
                return;
            }

            int productId = Convert.ToInt32(value);
            string productName = nameValue?.ToString() ?? "this product";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete '{productName}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var db = new DatabaseConnector();
                const string deleteQuery = "DELETE FROM dbo.Products WHERE ProductId = @ProductId";
                var parameters = new[] {
                    new System.Data.SqlClient.SqlParameter("@ProductId", productId)
                };

                int rowsAffected = db.ExecuteNonQuery(deleteQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Deleted successfully.");
                    LoadProductsWithCategory();
                    textBox1.Clear();
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("Product deletion failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // no-op
        }

        /// <summary>
        /// Reorder rows so matches come first (starts-with, then contains, then others).
        /// Keeps all rows visible.
        /// </summary>
        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (_allProducts == null || _allProducts.Rows.Count == 0)
                return;

            string term = (sender as TextBox)?.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(term))
            {
                // back to original order
                BindGrid(_allProducts);
                return;
            }

            // Order: starts-with term -> contains term -> others
            var orderedRows = _allProducts
                .AsEnumerable()
                .OrderBy(r =>
                {
                    var name = (r.Field<string>("ProductName") ?? string.Empty);
                    if (name.StartsWith(term, StringComparison.OrdinalIgnoreCase)) return 0;
                    if (name.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) return 1;
                    return 2;
                })
                .ThenBy(r => r.Field<string>("ProductName") ?? string.Empty)
                .ToList();

            var dtOrdered = _allProducts.Clone();
            foreach (var r in orderedRows)
                dtOrdered.Rows.Add(r.ItemArray);

            BindGrid(dtOrdered);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
