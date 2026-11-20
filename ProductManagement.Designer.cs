namespace GlowMate
{
    partial class ProductManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagement));
            this.ProductAddBtn = new System.Windows.Forms.Button();
            this.ProductDeleteBtn = new System.Windows.Forms.Button();
            this.ProductUpdateBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ProductBackBtn = new System.Windows.Forms.Button();
            this.SearchTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductAddBtn
            // 
            this.ProductAddBtn.BackColor = System.Drawing.Color.HotPink;
            this.ProductAddBtn.FlatAppearance.BorderSize = 0;
            this.ProductAddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductAddBtn.ForeColor = System.Drawing.Color.Black;
            this.ProductAddBtn.Location = new System.Drawing.Point(221, 474);
            this.ProductAddBtn.Name = "ProductAddBtn";
            this.ProductAddBtn.Size = new System.Drawing.Size(122, 39);
            this.ProductAddBtn.TabIndex = 1;
            this.ProductAddBtn.Text = "Add";
            this.ProductAddBtn.UseVisualStyleBackColor = false;
            this.ProductAddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductDeleteBtn
            // 
            this.ProductDeleteBtn.BackColor = System.Drawing.Color.HotPink;
            this.ProductDeleteBtn.FlatAppearance.BorderSize = 0;
            this.ProductDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductDeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductDeleteBtn.ForeColor = System.Drawing.Color.Black;
            this.ProductDeleteBtn.Location = new System.Drawing.Point(596, 474);
            this.ProductDeleteBtn.Name = "ProductDeleteBtn";
            this.ProductDeleteBtn.Size = new System.Drawing.Size(122, 39);
            this.ProductDeleteBtn.TabIndex = 2;
            this.ProductDeleteBtn.Text = "Delete";
            this.ProductDeleteBtn.UseVisualStyleBackColor = false;
            this.ProductDeleteBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ProductUpdateBtn
            // 
            this.ProductUpdateBtn.BackColor = System.Drawing.Color.HotPink;
            this.ProductUpdateBtn.FlatAppearance.BorderSize = 0;
            this.ProductUpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductUpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductUpdateBtn.ForeColor = System.Drawing.Color.Black;
            this.ProductUpdateBtn.Location = new System.Drawing.Point(412, 474);
            this.ProductUpdateBtn.Name = "ProductUpdateBtn";
            this.ProductUpdateBtn.Size = new System.Drawing.Size(122, 39);
            this.ProductUpdateBtn.TabIndex = 3;
            this.ProductUpdateBtn.Text = "Update";
            this.ProductUpdateBtn.UseVisualStyleBackColor = false;
            this.ProductUpdateBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView2.Location = new System.Drawing.Point(12, 146);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(772, 288);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Product ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 91;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Product Name";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 112;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Category Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantity";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 84;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Manufactured Date";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 137;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Expiry Date";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 97;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Status";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(157)))), ((int)(((byte)(190)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(787, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(157)))), ((int)(((byte)(190)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(787, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Image";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(790, 146);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 149);
            this.textBox1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(790, 342);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 156);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ProductBackBtn
            // 
            this.ProductBackBtn.BackColor = System.Drawing.Color.Transparent;
            this.ProductBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProductBackBtn.FlatAppearance.BorderSize = 0;
            this.ProductBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProductBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProductBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductBackBtn.ForeColor = System.Drawing.Color.Transparent;
            this.ProductBackBtn.Location = new System.Drawing.Point(65, 505);
            this.ProductBackBtn.Name = "ProductBackBtn";
            this.ProductBackBtn.Size = new System.Drawing.Size(123, 23);
            this.ProductBackBtn.TabIndex = 12;
            this.ProductBackBtn.UseVisualStyleBackColor = false;
            this.ProductBackBtn.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTextbox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SearchTextbox.Location = new System.Drawing.Point(737, 72);
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.Size = new System.Drawing.Size(128, 15);
            this.SearchTextbox.TabIndex = 13;
            this.SearchTextbox.TextChanged += new System.EventHandler(this.SearchTextbox_TextChanged);
            // 
            // ProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 553);
            this.Controls.Add(this.SearchTextbox);
            this.Controls.Add(this.ProductBackBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.ProductUpdateBtn);
            this.Controls.Add(this.ProductDeleteBtn);
            this.Controls.Add(this.ProductAddBtn);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ProductManagement";
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ProductAddBtn;
        private System.Windows.Forms.Button ProductDeleteBtn;
        private System.Windows.Forms.Button ProductUpdateBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ProductBackBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TextBox SearchTextbox;
    }
}