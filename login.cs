using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GlowMate
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
            // Hide password characters in the password textbox
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to Sign-Up form
            Signup signupForm = new Signup();
            signupForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true; // Hide password characters
        }

        // Optional: Remove if not used
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Signup form = new Signup();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)

        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Admin login shortcut
            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("Welcome Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminDashboard adminForm = new AdminDashboard();  // You must create Form3
                adminForm.Show();
                this.Hide();
                return;
            }

            // Validate regular user from database
            DatabaseConnector db = new DatabaseConnector();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            SqlParameter[] parameters = {

                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            object result = db.ExecuteScalar(query, parameters);

            if (Convert.ToInt32(result) > 0)
            {
                MessageBox.Show("Welcome User!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open User Dashboard here
                // Form4 userDashboard = new Form4();
                // userDashboard.Show();
                UserProduct userForm = new UserProduct(); // User Product View Form
                userForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}