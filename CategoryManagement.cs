using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class CategoryManagement : Form
    {
        public CategoryManagement()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadCategories(); // initial load with no search term
        }

        /// <summary>
        /// Loads / refreshes the grid. If a searchTerm is provided, rows that match it
        /// (exact / starts-with / contains) are sorted to the top, but all rows remain visible.
        /// </summary>
        private void LoadCategories(string searchTerm = null)
        {
            try
            {
                var db = new DatabaseConnector();

                // Base projection
                string sql = @"
                    SELECT
                        CategoryId   AS [Category ID],
                        CategoryName AS [Category Name],
                        Active,
                        ProductCount AS [Product Count]
                    FROM dbo.Categories
                ";

                SqlParameter[] parameters = Array.Empty<SqlParameter>();

                // If there's a search term, order by match strength first
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    sql += @"
                    ORDER BY
                        CASE
                            WHEN CategoryName = @term THEN 0                              -- exact match
                            WHEN CategoryName LIKE @termStarts THEN 1                    -- starts with
                            WHEN CategoryName LIKE @termContains THEN 2                  -- contains
                            ELSE 3
                        END,
                        CategoryId;
                    ";

                    parameters = new[]
                    {
                        new SqlParameter("@term", searchTerm.Trim()),
                        new SqlParameter("@termStarts", searchTerm.Trim() + "%"),
                        new SqlParameter("@termContains", "%" + searchTerm.Trim() + "%")
                    };
                }
                else
                {
                    // Default order (no search term)
                    sql += " ORDER BY CategoryId;";
                }

                DataTable dt = db.ExecuteQuery(sql, parameters);

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

                UpdateAddButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        /// <summary>
        /// Enables Add only when there are fewer than 6 rows.
        /// </summary>
        private void UpdateAddButtonState()
        {
            int count = 0;
            if (dataGridView1.DataSource is DataTable dt)
                count = dt.Rows.Count;

            CategoryAddBtn.Enabled = count < 6;
        }

        // Add
        private void button1_Click(object sender, EventArgs e)
        {
            var f = new CategoryPage(this);
            f.FormClosed += (s, args) =>
            {
                this.Show();
                LoadCategories(SearchTextBox.Text); // keep current search ordering
            };
            this.Hide();
            f.Show();
        }

        // Update
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            var rowView = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null)
            {
                MessageBox.Show("Please select a valid row.");
                return;
            }

            var f = new CategoryPage(rowView.Row, this);
            f.FormClosed += (s, args) =>
            {
                this.Show();
                LoadCategories(SearchTextBox.Text); // keep current search ordering
            };
            this.Hide();
            f.Show();
        }

        // Delete
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int categoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Category ID"].Value);
            string categoryName = Convert.ToString(dataGridView1.CurrentRow.Cells["Category Name"].Value);

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete '{categoryName}'?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var db = new DatabaseConnector();

                // Block delete if products still reference this category
                int used = Convert.ToInt32(db.ExecuteScalar(
                    "SELECT COUNT(*) FROM dbo.Products WHERE CategoryId = @id",
                    new[] { new SqlParameter("@id", categoryId) }));

                if (used > 0)
                {
                    MessageBox.Show(
                        $"Cannot delete: {used} product(s) still reference this category.\n" +
                        "Delete or reassign those product(s) first, then try again.",
                        "Delete blocked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                db.ExecuteNonQuery(
                    "DELETE FROM dbo.Categories WHERE CategoryId = @id",
                    new[] { new SqlParameter("@id", categoryId) });

                LoadCategories(SearchTextBox.Text); // refresh with current search ordering
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message);
            }
        }

        // Back
        private void button4_Click(object sender, EventArgs e)
        {
            var admin = new AdminDashboard();
            admin.Show();
            this.Hide();
        }

        // Grid click (unused)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // Search textbox — live reorder as the user types
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string term = SearchTextBox.Text;
            LoadCategories(term);
        }

        // Optional Search button (does the same as typing)
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string term = SearchTextBox.Text;
            LoadCategories(term);
        }
    }
}
