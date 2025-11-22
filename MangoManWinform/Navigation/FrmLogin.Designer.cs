namespace MangoManWinform.Navigation
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Login_close = new System.Windows.Forms.Label();
            this.Login_Register = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Login_Showpassword = new System.Windows.Forms.CheckBox();
            this.Login_btn = new System.Windows.Forms.Button();
            this.Login_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Login_Username = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Login_close);
            this.panel1.Controls.Add(this.Login_Register);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Login_Showpassword);
            this.panel1.Controls.Add(this.Login_btn);
            this.panel1.Controls.Add(this.Login_Password);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Login_Username);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1445, 759);
            this.panel1.TabIndex = 1;
            // 
            // Login_close
            // 
            this.Login_close.AutoSize = true;
            this.Login_close.Location = new System.Drawing.Point(1370, 18);
            this.Login_close.Name = "Login_close";
            this.Login_close.Size = new System.Drawing.Size(15, 16);
            this.Login_close.TabIndex = 13;
            this.Login_close.Text = "X";
            this.Login_close.Click += new System.EventHandler(this.Login_close_Click);
            // 
            // Login_Register
            // 
            this.Login_Register.AutoSize = true;
            this.Login_Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Register.Location = new System.Drawing.Point(906, 664);
            this.Login_Register.Name = "Login_Register";
            this.Login_Register.Size = new System.Drawing.Size(123, 20);
            this.Login_Register.TabIndex = 9;
            this.Login_Register.Text = "Register here";
            this.Login_Register.Click += new System.EventHandler(this.Login_Register_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(710, 664);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Don\'t have an account ?";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Login_Showpassword
            // 
            this.Login_Showpassword.AutoSize = true;
            this.Login_Showpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Showpassword.Location = new System.Drawing.Point(1236, 454);
            this.Login_Showpassword.Name = "Login_Showpassword";
            this.Login_Showpassword.Size = new System.Drawing.Size(149, 24);
            this.Login_Showpassword.TabIndex = 7;
            this.Login_Showpassword.Text = "Show password";
            this.Login_Showpassword.UseVisualStyleBackColor = true;
            this.Login_Showpassword.CheckedChanged += new System.EventHandler(this.Login_Showpassword_CheckedChanged);
            // 
            // Login_btn
            // 
            this.Login_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.Login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Login_btn.Location = new System.Drawing.Point(714, 504);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(146, 56);
            this.Login_btn.TabIndex = 6;
            this.Login_btn.Text = "Login";
            this.Login_btn.UseVisualStyleBackColor = false;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // Login_Password
            // 
            this.Login_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Password.Location = new System.Drawing.Point(714, 402);
            this.Login_Password.Multiline = true;
            this.Login_Password.Name = "Login_Password";
            this.Login_Password.Size = new System.Drawing.Size(671, 46);
            this.Login_Password.TabIndex = 5;
            this.Login_Password.TextChanged += new System.EventHandler(this.Login_Password_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(709, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(709, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(697, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome Back!";
            // 
            // Login_Username
            // 
            this.Login_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Username.Location = new System.Drawing.Point(714, 262);
            this.Login_Username.Multiline = true;
            this.Login_Username.Name = "Login_Username";
            this.Login_Username.Size = new System.Drawing.Size(671, 46);
            this.Login_Username.TabIndex = 1;
            this.Login_Username.TextChanged += new System.EventHandler(this.Login_Username_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Peru;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 756);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MangoManWinform.Properties.Resources.icons8_login_64;
            this.pictureBox1.Location = new System.Drawing.Point(181, 212);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 52);
            this.label6.TabIndex = 0;
            this.label6.Text = "Your inventory. Your control. \r\nLet’s get you logged in.";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1447, 760);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Login_Username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.TextBox Login_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Login_Showpassword;
        private System.Windows.Forms.Label Login_Register;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Login_close;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}