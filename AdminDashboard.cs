using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductManagement productForm = new ProductManagement();
            productForm.Show();
            this.Hide(); // Hide Admin Dashboard

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryManagement categoryForm = new CategoryManagement();
            categoryForm.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FeedbackManagement feedbackForm = new FeedbackManagement();
            feedbackForm.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to logout?",
               "Logout Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                login loginForm = new login();
                loginForm.Show();
                this.Hide();
            }

        }
    }
}
