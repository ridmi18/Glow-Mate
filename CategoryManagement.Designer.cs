namespace GlowMate
{
    partial class CategoryManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryManagement));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryAddBtn = new System.Windows.Forms.Button();
            this.CategoryDeleteBtn = new System.Windows.Forms.Button();
            this.CategoryUpdateBtn = new System.Windows.Forms.Button();
            this.CategoryBackBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(178, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(454, 262);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Category ID";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 99;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Category Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Active";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 73;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Product Count";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 110;
            // 
            // CategoryAddBtn
            // 
            this.CategoryAddBtn.BackColor = System.Drawing.Color.HotPink;
            this.CategoryAddBtn.FlatAppearance.BorderSize = 0;
            this.CategoryAddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CategoryAddBtn.ForeColor = System.Drawing.Color.Black;
            this.CategoryAddBtn.Location = new System.Drawing.Point(178, 448);
            this.CategoryAddBtn.Name = "CategoryAddBtn";
            this.CategoryAddBtn.Size = new System.Drawing.Size(122, 39);
            this.CategoryAddBtn.TabIndex = 2;
            this.CategoryAddBtn.Text = "Add";
            this.CategoryAddBtn.UseVisualStyleBackColor = false;
            this.CategoryAddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // CategoryDeleteBtn
            // 
            this.CategoryDeleteBtn.BackColor = System.Drawing.Color.HotPink;
            this.CategoryDeleteBtn.FlatAppearance.BorderSize = 0;
            this.CategoryDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryDeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CategoryDeleteBtn.ForeColor = System.Drawing.Color.Black;
            this.CategoryDeleteBtn.Location = new System.Drawing.Point(510, 448);
            this.CategoryDeleteBtn.Name = "CategoryDeleteBtn";
            this.CategoryDeleteBtn.Size = new System.Drawing.Size(122, 39);
            this.CategoryDeleteBtn.TabIndex = 3;
            this.CategoryDeleteBtn.Text = "Delete";
            this.CategoryDeleteBtn.UseVisualStyleBackColor = false;
            this.CategoryDeleteBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // CategoryUpdateBtn
            // 
            this.CategoryUpdateBtn.BackColor = System.Drawing.Color.HotPink;
            this.CategoryUpdateBtn.FlatAppearance.BorderSize = 0;
            this.CategoryUpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryUpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CategoryUpdateBtn.ForeColor = System.Drawing.Color.Black;
            this.CategoryUpdateBtn.Location = new System.Drawing.Point(352, 448);
            this.CategoryUpdateBtn.Name = "CategoryUpdateBtn";
            this.CategoryUpdateBtn.Size = new System.Drawing.Size(122, 39);
            this.CategoryUpdateBtn.TabIndex = 4;
            this.CategoryUpdateBtn.Text = "Update";
            this.CategoryUpdateBtn.UseVisualStyleBackColor = false;
            this.CategoryUpdateBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // CategoryBackBtn
            // 
            this.CategoryBackBtn.BackColor = System.Drawing.Color.Transparent;
            this.CategoryBackBtn.FlatAppearance.BorderSize = 0;
            this.CategoryBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CategoryBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CategoryBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryBackBtn.Location = new System.Drawing.Point(69, 505);
            this.CategoryBackBtn.Name = "CategoryBackBtn";
            this.CategoryBackBtn.Size = new System.Drawing.Size(117, 23);
            this.CategoryBackBtn.TabIndex = 5;
            this.CategoryBackBtn.UseVisualStyleBackColor = false;
            this.CategoryBackBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.Transparent;
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SearchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Location = new System.Drawing.Point(654, 70);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(70, 23);
            this.SearchBtn.TabIndex = 6;
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTextBox.Location = new System.Drawing.Point(736, 71);
            this.SearchTextBox.Multiline = true;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(147, 17);
            this.SearchTextBox.TabIndex = 7;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // CategoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 553);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.CategoryBackBtn);
            this.Controls.Add(this.CategoryUpdateBtn);
            this.Controls.Add(this.CategoryDeleteBtn);
            this.Controls.Add(this.CategoryAddBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CategoryManagement";
            this.Text = "Category Management";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button CategoryAddBtn;
        private System.Windows.Forms.Button CategoryDeleteBtn;
        private System.Windows.Forms.Button CategoryUpdateBtn;
        private System.Windows.Forms.Button CategoryBackBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchTextBox;
    }
}
