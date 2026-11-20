namespace GlowMate
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.AccountCreateBtn = new System.Windows.Forms.Button();
            this.LoginBtnS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(213, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 15);
            this.textBox1.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(218, 260);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(211, 15);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(534, 254);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(202, 15);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(218, 329);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(211, 15);
            this.textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(534, 329);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(220, 15);
            this.textBox6.TabIndex = 5;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(535, 188);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(219, 15);
            this.textBox2.TabIndex = 6;
            // 
            // AccountCreateBtn
            // 
            this.AccountCreateBtn.BackColor = System.Drawing.Color.Transparent;
            this.AccountCreateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AccountCreateBtn.FlatAppearance.BorderSize = 0;
            this.AccountCreateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AccountCreateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AccountCreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountCreateBtn.Location = new System.Drawing.Point(413, 381);
            this.AccountCreateBtn.Name = "AccountCreateBtn";
            this.AccountCreateBtn.Size = new System.Drawing.Size(115, 23);
            this.AccountCreateBtn.TabIndex = 7;
            this.AccountCreateBtn.UseVisualStyleBackColor = false;
            this.AccountCreateBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // LoginBtnS
            // 
            this.LoginBtnS.BackColor = System.Drawing.Color.Transparent;
            this.LoginBtnS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginBtnS.FlatAppearance.BorderSize = 0;
            this.LoginBtnS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LoginBtnS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LoginBtnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtnS.Location = new System.Drawing.Point(450, 446);
            this.LoginBtnS.Name = "LoginBtnS";
            this.LoginBtnS.Size = new System.Drawing.Size(53, 19);
            this.LoginBtnS.TabIndex = 8;
            this.LoginBtnS.UseVisualStyleBackColor = false;
            this.LoginBtnS.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 553);
            this.Controls.Add(this.LoginBtnS);
            this.Controls.Add(this.AccountCreateBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Name = "Signup";
            this.Text = "Signup";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button AccountCreateBtn;
        private System.Windows.Forms.Button LoginBtnS;
    }
}