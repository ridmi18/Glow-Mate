using System;
using System.Data.SqlClient;
using System.Linq;                 // for char.IsDigit + Where
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class UserFeedback : Form
    {
        private readonly ErrorProvider _ep = new ErrorProvider();

        public UserFeedback()
        {
            InitializeComponent();
            _ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void Form11_Load(object sender, EventArgs e) { }

        // ===== Submit =====
        private void button1_Click(object sender, EventArgs e)
        {
            // Run all validators (single & so all errors show at once)
            bool ok =
                ValidateName() &
                ValidateContact() &
                ValidateEmail() &
                ValidateComment();

            if (!ok)
            {
                MessageBox.Show("Please correct the highlighted errors before submitting.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = textBox1.Text.Trim();
            string contact = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string comment = textBox4.Text.Trim();

            try
            {
                var db = new DatabaseConnector();
                string insertSql = @"
                    INSERT INTO dbo.Feedbacks (Name, ContactNumber, Email, Comment, CreatedAt)
                    VALUES (@name, @contact, @email, @comment, SYSDATETIME());";

                var p = new[]
                {
                    new SqlParameter("@name",    name),
                    new SqlParameter("@contact", (object)contact ?? DBNull.Value),
                    new SqlParameter("@email",   (object)email   ?? DBNull.Value),
                    new SqlParameter("@comment", comment),
                };

                db.ExecuteNonQuery(insertSql, p);

                MessageBox.Show("Thank you for your feedback!", "Submitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                var userForm = new UserProduct();
                userForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to submit feedback: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== TextChanged handlers expected by Designer =====
        private void textBox1_TextChanged(object sender, EventArgs e) => ValidateName();
        private void textBox2_TextChanged(object sender, EventArgs e) => ValidateContact();
        private void textBox3_TextChanged(object sender, EventArgs e) => ValidateEmail();
        private void textBox4_TextChanged(object sender, EventArgs e) => ValidateComment();

        // ===== Validators =====
        private bool ValidateName()
        {
            string name = textBox1.Text.Trim();
            // Only letters & spaces
            bool ok = !string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[A-Za-z\s]+$");
            _ep.SetError(textBox1, ok ? "" : "Name must only contain letters and spaces.");
            return ok;
        }

        private bool ValidateContact()
        {
            // Accept only 10 digits (ignore spaces/dashes if ever present)
            string digits = new string(textBox2.Text.Where(char.IsDigit).ToArray());
            bool ok = digits.Length == 10;
            _ep.SetError(textBox2, ok ? "" : "Contact number must be exactly 10 digits.");
            return ok;
        }

        private bool ValidateEmail()
        {
            string email = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                // Optional field: no error when empty
                _ep.SetError(textBox3, "");
                return true;
            }

            // Robust email pattern; TLD must be at least 2 letters
            const string pattern =
                @"^(?=.{1,254}$)(?=.{1,64}@)" +   // length limits
                @"(?!.*\.\.)" +                   // no consecutive dots
                @"[A-Za-z0-9._%+-]+@" +
                @"(?:[A-Za-z0-9-]+\.)+" +
                @"[A-Za-z]{2,}$";                 // <-- enforces .com, .lk, etc. (not .c)

            bool ok = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            _ep.SetError(textBox3, ok ? "" : "Please enter a valid email address.");
            return ok;
        }

        private bool ValidateComment()
        {
            string c = textBox4.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(c);
            _ep.SetError(textBox4, ok ? "" : "Please enter a comment.");
            return ok;
        }
    }
}
