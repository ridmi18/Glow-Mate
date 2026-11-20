namespace GlowMate
{
    partial class CategoryPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryPage));
            this.CategorySaveBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.CategoryPageBackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategorySaveBtn
            // 
            this.CategorySaveBtn.BackColor = System.Drawing.Color.Transparent;
            this.CategorySaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CategorySaveBtn.FlatAppearance.BorderSize = 0;
            this.CategorySaveBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CategorySaveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CategorySaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategorySaveBtn.ForeColor = System.Drawing.Color.Transparent;
            this.CategorySaveBtn.Location = new System.Drawing.Point(364, 407);
            this.CategorySaveBtn.Name = "CategorySaveBtn";
            this.CategorySaveBtn.Size = new System.Drawing.Size(107, 27);
            this.CategorySaveBtn.TabIndex = 3;
            this.CategorySaveBtn.UseVisualStyleBackColor = false;
            this.CategorySaveBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(388, 267);
            this.textBox1.MaxLength = 9;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 15);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress_DigitsOnly);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(381, 139);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(381, 199);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(225, 24);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // CategoryPageBackBtn
            // 
            this.CategoryPageBackBtn.BackColor = System.Drawing.Color.Transparent;
            this.CategoryPageBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CategoryPageBackBtn.FlatAppearance.BorderSize = 0;
            this.CategoryPageBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CategoryPageBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CategoryPageBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryPageBackBtn.ForeColor = System.Drawing.Color.Transparent;
            this.CategoryPageBackBtn.Location = new System.Drawing.Point(132, 407);
            this.CategoryPageBackBtn.Name = "CategoryPageBackBtn";
            this.CategoryPageBackBtn.Size = new System.Drawing.Size(98, 26);
            this.CategoryPageBackBtn.TabIndex = 4;
            this.CategoryPageBackBtn.UseVisualStyleBackColor = false;
            this.CategoryPageBackBtn.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CategoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CategoryPageBackBtn);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CategorySaveBtn);
            this.Name = "CategoryPage";
            this.Text = "Category Page";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CategorySaveBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button CategoryPageBackBtn;
    }
}
