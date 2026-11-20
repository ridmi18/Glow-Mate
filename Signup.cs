using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class Signup : Form
    {
        

        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Read all inputs
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string contact = textBox3.Text.Trim();
            string username = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();
            string confirmPassword = textBox6.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if username exists
            DatabaseConnector db = new DatabaseConnector();
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            SqlParameter[] checkParams = {
                new SqlParameter("@Username", username)
            };
            object exists = db.ExecuteScalar(checkQuery, checkParams);

            if (Convert.ToInt32(exists) > 0)
            {
                MessageBox.Show("Username already exists. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert into DB
            string insertQuery = "INSERT INTO Users (FirstName, LastName, Contact, Username, Password) VALUES (@FirstName, @LastName, @Contact, @Username, @Password)";
            SqlParameter[] insertParams = {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Contact", contact),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            int result = db.ExecuteNonQuery(insertQuery, insertParams);

            if (result > 0)
            {
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login loginForm = new login();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something went wrong. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
            textBox6.UseSystemPasswordChar = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            login FM = new login();
            FM.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Read all inputs
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string contact = textBox3.Text.Trim();
            string username = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();
            string confirmPassword = textBox6.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if username exists
            DatabaseConnector db = new DatabaseConnector();
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            SqlParameter[] checkParams = {
                new SqlParameter("@Username", username)
            };
            object exists = db.ExecuteScalar(checkQuery, checkParams);

            if (Convert.ToInt32(exists) > 0)
            {
                MessageBox.Show("Username already exists. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert into DB
            string insertQuery = "INSERT INTO Users (FirstName, LastName, Contact, Username, Password) VALUES (@FirstName, @LastName, @Contact, @Username, @Password)";
            SqlParameter[] insertParams = {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Contact", contact),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            int result = db.ExecuteNonQuery(insertQuery, insertParams);

            if (result > 0)
            {
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login loginForm = new login();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something went wrong. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
