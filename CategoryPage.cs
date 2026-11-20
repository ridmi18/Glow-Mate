using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class CategoryPage : Form
    {
        private readonly CategoryManagement _parent;
        private readonly bool _isUpdateMode = false;
        private readonly int _categoryId = -1;
        private readonly string _categoryName = null;

        // Small helper for inline validation UI
        private readonly ErrorProvider _ep = new ErrorProvider();

        // Fixed mapping (Name -> ID)
        private static readonly Dictionary<string, int> CategoryIdMap =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "Skincare",  1 },
                { "Makeup",    2 },
                { "Haircare",  3 },
                { "Bodycare",  4 },
                { "Nailcare",  5 },
                { "Fragrance", 6 },
            };

        // Add mode
        public CategoryPage(CategoryManagement parent = null)
        {
            InitializeComponent();
            _parent = parent;
        }

        // Update mode
        public CategoryPage(DataRow row, CategoryManagement parent = null)
        {
            InitializeComponent();
            _parent = parent;

            _isUpdateMode = true;
            _categoryId = Convert.ToInt32(row["Category ID"]);
            _categoryName = row["Category Name"].ToString();

            // Only these can be changed in Update mode
            comboBox2.Text = row["Active"].ToString();
            textBox1.Text = row["Product Count"].ToString();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // ErrorProvider setup
            _ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _ep.ContainerControl = this;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadAllCategoryNames();

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Available");
            comboBox2.Items.Add("Not Available");

            if (_isUpdateMode)
            {
                // Category name is tied to a fixed ID; lock it in update mode
                comboBox1.Enabled = false;

                if (!string.IsNullOrWhiteSpace(_categoryName))
                {
                    var idx = comboBox1.FindStringExact(_categoryName);
                    if (idx >= 0) comboBox1.SelectedIndex = idx;
                }
            }
            else
            {
                if (comboBox1.Items.Count > 0 && comboBox1.SelectedIndex < 0)
                    comboBox1.SelectedIndex = 0;
            }

            // Restrict keystrokes to digits/backspace
            textBox1.KeyPress -= textBox1_KeyPress_DigitsOnly;
            textBox1.KeyPress += textBox1_KeyPress_DigitsOnly;

            // Live validation whenever text changes
            textBox1.TextChanged -= textBox1_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;

            // Ensure Save button is pointing to our single save method
            CategorySaveBtn.Click -= button1_Click;
            CategorySaveBtn.Click -= button1_Click_1;
            CategorySaveBtn.Click += button1_Click;

            // Trigger initial validation state
            textBox1_TextChanged(textBox1, EventArgs.Empty);
        }

        private void LoadAllCategoryNames()
        {
            try
            {
                var db = new DatabaseConnector();
                var dt = db.ExecuteQuery(@"
                    SELECT CategoryName
                    FROM dbo.Categories
                    GROUP BY CategoryName
                    ORDER BY CategoryName;");

                comboBox1.Items.Clear();

                // Existing names from DB
                foreach (DataRow r in dt.Rows)
                {
                    var name = r["CategoryName"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(name) && comboBox1.Items.IndexOf(name) < 0)
                        comboBox1.Items.Add(name);
                }

                // Guarantee canonical six are present
                foreach (var name in CategoryIdMap.Keys)
                {
                    if (comboBox1.Items.IndexOf(name) < 0)
                        comboBox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load category names: " + ex.Message,
                                "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Designer may have wired both of these; keep both pointing to the same method
        private void button1_Click(object sender, EventArgs e) => SaveCategory();
        private void button1_Click_1(object sender, EventArgs e) => SaveCategory();

        private void SaveCategory()
        {
            // Guard: don't allow saving if product count is invalid
            if (!IsProductCountValid(textBox1.Text, showErrors: true))
                return;

            string name = comboBox1.Text?.Trim();
            string active = comboBox2.Text?.Trim();
            string countText = textBox1.Text?.Trim();

            // Validation for other fields
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(active))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (active != "Available" && active != "Not Available")
            {
                MessageBox.Show("Active must be either 'Available' or 'Not Available'.");
                return;
            }

            int productCount = int.Parse(countText); // safe after IsProductCountValid

            var db = new DatabaseConnector();

            try
            {
                if (_isUpdateMode)
                {
                    // Only Active & ProductCount are updated
                    const string updateSql = @"
                        UPDATE dbo.Categories
                           SET Active       = @active,
                               ProductCount = @count
                         WHERE CategoryId   = @id;";

                    var p = new[]
                    {
                        new SqlParameter("@active", active),
                        new SqlParameter("@count",  productCount),
                        new SqlParameter("@id",     _categoryId),
                    };

                    db.ExecuteNonQuery(updateSql, p);
                    MessageBox.Show("Category updated.");
                }
                else
                {
                    // ADD MODE with fixed ID per name
                    if (!CategoryIdMap.TryGetValue(name, out int fixedId))
                    {
                        MessageBox.Show("Only these category names are allowed:\nSkincare, Makeup, Haircare, Bodycare, Nailcare, Fragrance.");
                        return;
                    }

                    // Block duplicates by name or ID
                    int nameExists = Convert.ToInt32(db.ExecuteScalar(
                        "SELECT COUNT(*) FROM dbo.Categories WHERE CategoryName = @name",
                        new[] { new SqlParameter("@name", name) }));

                    int idExists = Convert.ToInt32(db.ExecuteScalar(
                        "SELECT COUNT(*) FROM dbo.Categories WHERE CategoryId = @id",
                        new[] { new SqlParameter("@id", fixedId) }));

                    if (nameExists > 0 || idExists > 0)
                    {
                        MessageBox.Show(
                            $"'{name}' already exists (ID {fixedId}). " +
                            "Delete it first if you need to add it again.");
                        return;
                    }

                    // Insert with the fixed ID (IDENTITY_INSERT)
                    const string insertWithFixedId = @"
SET IDENTITY_INSERT dbo.Categories ON;
INSERT INTO dbo.Categories (CategoryId, CategoryName, Active, ProductCount)
VALUES (@id, @name, @active, @count);
SET IDENTITY_INSERT dbo.Categories OFF;";

                    var p = new[]
                    {
                        new SqlParameter("@id",     fixedId),
                        new SqlParameter("@name",   name),
                        new SqlParameter("@active", active),
                        new SqlParameter("@count",  productCount),
                    };

                    db.ExecuteNonQuery(insertWithFixedId, p);
                    MessageBox.Show("Category added.");
                }

                TryRefreshParent();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving category: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryRefreshParent()
        {
            if (_parent == null) return;

            try
            {
                var t = _parent.GetType();
                var mi = t.GetMethod("LoadCategories",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.NonPublic,
                        binder: null,
                        types: Type.EmptyTypes,
                        modifiers: null);

                if (mi != null)
                {
                    mi.Invoke(_parent, null);
                }
                else
                {
                    mi = t.GetMethod("LoadCategories",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.NonPublic,
                        binder: null,
                        types: new[] { typeof(string) },
                        modifiers: null);

                    if (mi != null)
                        mi.Invoke(_parent, new object[] { "" });
                }

                _parent.Show();
            }
            catch
            {
                try { _parent.Show(); } catch { /* ignore */ }
            }
        }

        private void textBox1_KeyPress_DigitsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Live validation for Product Count
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IsProductCountValid(textBox1.Text, showErrors: false);
        }

        // Central validation logic so Save can call it too
        private bool IsProductCountValid(string text, bool showErrors)
        {
            string msg = null;

            if (string.IsNullOrWhiteSpace(text))
                msg = "Product Count is required.";
            else if (!int.TryParse(text.Trim(), out int n))
                msg = "Product Count must be a whole number.";
            else if (n < 0)
                msg = "Product Count cannot be negative.";
            else if (n > 1_000_000)
                msg = "Product Count is too large (max 1,000,000).";

            bool ok = msg == null;

            // UI feedback
            CategorySaveBtn.Enabled = ok;
            textBox1.BackColor = ok ? System.Drawing.Color.White : System.Drawing.Color.MistyRose;

            if (ok)
                _ep.SetError(textBox1, "");
            else
                _ep.SetError(textBox1, msg);

            if (!ok && showErrors)
                MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return ok;
        }

        // Back button from designer
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_parent != null) _parent.Show();
            else new CategoryManagement().Show();
            Close();
        }

        // Optional designer events
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
