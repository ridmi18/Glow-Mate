namespace GlowMate
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.ProductsBtn = new System.Windows.Forms.Button();
            this.CategoryBtn = new System.Windows.Forms.Button();
            this.FeedbacksBtn = new System.Windows.Forms.Button();
            this.AdminLogoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProductsBtn
            // 
            this.ProductsBtn.BackColor = System.Drawing.Color.Transparent;
            this.ProductsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProductsBtn.FlatAppearance.BorderSize = 0;
            this.ProductsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProductsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProductsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductsBtn.Location = new System.Drawing.Point(136, 244);
            this.ProductsBtn.Name = "ProductsBtn";
            this.ProductsBtn.Size = new System.Drawing.Size(249, 33);
            this.ProductsBtn.TabIndex = 0;
            this.ProductsBtn.UseVisualStyleBackColor = false;
            this.ProductsBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // CategoryBtn
            // 
            this.CategoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.CategoryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CategoryBtn.FlatAppearance.BorderSize = 0;
            this.CategoryBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CategoryBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CategoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryBtn.Location = new System.Drawing.Point(522, 241);
            this.CategoryBtn.Name = "CategoryBtn";
            this.CategoryBtn.Size = new System.Drawing.Size(221, 39);
            this.CategoryBtn.TabIndex = 1;
            this.CategoryBtn.UseVisualStyleBackColor = false;
            this.CategoryBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // FeedbacksBtn
            // 
            this.FeedbacksBtn.BackColor = System.Drawing.Color.Transparent;
            this.FeedbacksBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FeedbacksBtn.FlatAppearance.BorderSize = 0;
            this.FeedbacksBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FeedbacksBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FeedbacksBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FeedbacksBtn.Location = new System.Drawing.Point(331, 342);
            this.FeedbacksBtn.Name = "FeedbacksBtn";
            this.FeedbacksBtn.Size = new System.Drawing.Size(249, 41);
            this.FeedbacksBtn.TabIndex = 2;
            this.FeedbacksBtn.UseVisualStyleBackColor = false;
            this.FeedbacksBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // AdminLogoutBtn
            // 
            this.AdminLogoutBtn.BackColor = System.Drawing.Color.Transparent;
            this.AdminLogoutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AdminLogoutBtn.CausesValidation = false;
            this.AdminLogoutBtn.FlatAppearance.BorderSize = 0;
            this.AdminLogoutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AdminLogoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AdminLogoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdminLogoutBtn.ForeColor = System.Drawing.Color.Transparent;
            this.AdminLogoutBtn.Location = new System.Drawing.Point(402, 466);
            this.AdminLogoutBtn.Name = "AdminLogoutBtn";
            this.AdminLogoutBtn.Size = new System.Drawing.Size(137, 30);
            this.AdminLogoutBtn.TabIndex = 4;
            this.AdminLogoutBtn.TabStop = false;
            this.AdminLogoutBtn.UseVisualStyleBackColor = false;
            this.AdminLogoutBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 553);
            this.Controls.Add(this.AdminLogoutBtn);
            this.Controls.Add(this.FeedbacksBtn);
            this.Controls.Add(this.CategoryBtn);
            this.Controls.Add(this.ProductsBtn);
            this.Name = "AdminDashboard";
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProductsBtn;
        private System.Windows.Forms.Button CategoryBtn;
        private System.Windows.Forms.Button FeedbacksBtn;
        private System.Windows.Forms.Button AdminLogoutBtn;
    }
}