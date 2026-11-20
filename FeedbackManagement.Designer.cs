namespace GlowMate
{
    partial class FeedbackManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackManagement));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FeedbackBtn = new System.Windows.Forms.Button();
            this.GenerateReportBtn = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(131, 160);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(240, 229);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FeedbackBtn
            // 
            this.FeedbackBtn.BackColor = System.Drawing.Color.Transparent;
            this.FeedbackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FeedbackBtn.FlatAppearance.BorderSize = 0;
            this.FeedbackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FeedbackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FeedbackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FeedbackBtn.ForeColor = System.Drawing.Color.Transparent;
            this.FeedbackBtn.Location = new System.Drawing.Point(72, 499);
            this.FeedbackBtn.Name = "FeedbackBtn";
            this.FeedbackBtn.Size = new System.Drawing.Size(112, 33);
            this.FeedbackBtn.TabIndex = 1;
            this.FeedbackBtn.UseVisualStyleBackColor = false;
            this.FeedbackBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerateReportBtn
            // 
            this.GenerateReportBtn.BackColor = System.Drawing.Color.Transparent;
            this.GenerateReportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GenerateReportBtn.FlatAppearance.BorderSize = 0;
            this.GenerateReportBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GenerateReportBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GenerateReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateReportBtn.ForeColor = System.Drawing.Color.Transparent;
            this.GenerateReportBtn.Location = new System.Drawing.Point(553, 491);
            this.GenerateReportBtn.Name = "GenerateReportBtn";
            this.GenerateReportBtn.Size = new System.Drawing.Size(202, 31);
            this.GenerateReportBtn.TabIndex = 2;
            this.GenerateReportBtn.UseVisualStyleBackColor = false;
            this.GenerateReportBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.Width = 73;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Comment";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 93;
            // 
            // FeedbackManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 553);
            this.Controls.Add(this.GenerateReportBtn);
            this.Controls.Add(this.FeedbackBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FeedbackManagement";
            this.Text = "Feedback Management";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button FeedbackBtn;
        private System.Windows.Forms.Button GenerateReportBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}