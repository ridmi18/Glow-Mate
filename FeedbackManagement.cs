using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GlowMate
{
    public partial class FeedbackManagement : Form
    {
        public FeedbackManagement()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadFeedbacks();
        }

        private void LoadFeedbacks()
        {
            try
            {
                var db = new DatabaseConnector();

                string query = @"
                    SELECT 
                        FeedbackId         AS [ID],
                        Name               AS [Name],
                        Comment            AS [Comment],
                        ContactNumber      AS [Contact],
                        Email              AS [Email],
                        CONVERT(varchar(19), CreatedAt, 120) AS [Created At]
                    FROM dbo.Feedbacks
                    ORDER BY CreatedAt DESC;";

                DataTable dt = db.ExecuteQuery(query);

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;

                // Show only Name + Comment in grid
                if (dataGridView1.Columns.Contains("ID"))
                    dataGridView1.Columns["ID"].Visible = false;
                if (dataGridView1.Columns.Contains("Contact"))
                    dataGridView1.Columns["Contact"].Visible = false;
                if (dataGridView1.Columns.Contains("Email"))
                    dataGridView1.Columns["Email"].Visible = false;
                if (dataGridView1.Columns.Contains("Created At"))
                    dataGridView1.Columns["Created At"].Visible = false;

                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load feedbacks: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Back
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button2_Click(object sender, EventArgs e) // Generate Report -> CSV
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Feedback Report";
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = string.Format("Feedbacks_{0:yyyyMMdd_HHmmss}.csv", DateTime.Now);

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder();

                    // headers
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0) sb.Append(',');
                        sb.Append(EscapeCsv(dt.Columns[i].ColumnName));
                    }
                    sb.AppendLine();

                    // rows
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i > 0) sb.Append(',');
                            string cell = row[i] == null ? string.Empty : row[i].ToString();
                            sb.Append(EscapeCsv(cell));
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Report saved.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save report: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string EscapeCsv(string input)
        {
            if (input == null) return string.Empty;
            if (input.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0)
                return "\"" + input.Replace("\"", "\"\"") + "\"";
            return input;
        }
    }
}
