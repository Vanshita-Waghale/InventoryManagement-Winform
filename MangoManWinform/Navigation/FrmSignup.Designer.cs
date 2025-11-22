namespace MangoManWinform.Navigation
{
    partial class FrmSignup
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
            this.Signup_close = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Signup_Emailid = new System.Windows.Forms.TextBox();
            this.Signup_login = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Signup_Showpassword = new System.Windows.Forms.CheckBox();
            this.Signup_btn = new System.Windows.Forms.Button();
            this.Signup_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Signup_Username = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Signup_close);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Signup_Emailid);
            this.panel1.Controls.Add(this.Signup_login);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Signup_Showpassword);
            this.panel1.Controls.Add(this.Signup_btn);
            this.panel1.Controls.Add(this.Signup_Password);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Signup_Username);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1428, 717);
            this.panel1.TabIndex = 2;
            // 
            // Signup_close
            // 
            this.Signup_close.AutoSize = true;
            this.Signup_close.Location = new System.Drawing.Point(1341, 18);
            this.Signup_close.Name = "Signup_close";
            this.Signup_close.Size = new System.Drawing.Size(15, 16);
            this.Signup_close.TabIndex = 12;
            this.Signup_close.Text = "X";
            this.Signup_close.Click += new System.EventHandler(this.Signup_close_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(719, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Email id";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Peru;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 714);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MangoManWinform.Properties.Resources.icons8_login_641;
            this.pictureBox1.Location = new System.Drawing.Point(181, 212);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 52);
            this.label6.TabIndex = 0;
            this.label6.Text = "Your inventory. Your control. \r\nLet’s get you Register.";
            // 
            // Signup_Emailid
            // 
            this.Signup_Emailid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_Emailid.Location = new System.Drawing.Point(714, 187);
            this.Signup_Emailid.Multiline = true;
            this.Signup_Emailid.Name = "Signup_Emailid";
            this.Signup_Emailid.Size = new System.Drawing.Size(671, 46);
            this.Signup_Emailid.TabIndex = 10;
            this.Signup_Emailid.TextChanged += new System.EventHandler(this.Signup_Emailid_TextChanged);
            // 
            // Signup_login
            // 
            this.Signup_login.AutoSize = true;
            this.Signup_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_login.Location = new System.Drawing.Point(906, 664);
            this.Signup_login.Name = "Signup_login";
            this.Signup_login.Size = new System.Drawing.Size(98, 20);
            this.Signup_login.TabIndex = 9;
            this.Signup_login.Text = "Login here";
            this.Signup_login.Click += new System.EventHandler(this.Signup_login_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(710, 664);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Already have an account ?";
            // 
            // Signup_Showpassword
            // 
            this.Signup_Showpassword.AutoSize = true;
            this.Signup_Showpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_Showpassword.Location = new System.Drawing.Point(1236, 454);
            this.Signup_Showpassword.Name = "Signup_Showpassword";
            this.Signup_Showpassword.Size = new System.Drawing.Size(149, 24);
            this.Signup_Showpassword.TabIndex = 7;
            this.Signup_Showpassword.Text = "Show password";
            this.Signup_Showpassword.UseVisualStyleBackColor = true;
            this.Signup_Showpassword.CheckedChanged += new System.EventHandler(this.Signup_Showpassword_CheckedChanged);
            // 
            // Signup_btn
            // 
            this.Signup_btn.BackColor = System.Drawing.Color.SeaGreen;
            this.Signup_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Signup_btn.Location = new System.Drawing.Point(714, 504);
            this.Signup_btn.Name = "Signup_btn";
            this.Signup_btn.Size = new System.Drawing.Size(146, 56);
            this.Signup_btn.TabIndex = 6;
            this.Signup_btn.Text = "SignUp";
            this.Signup_btn.UseVisualStyleBackColor = false;
            this.Signup_btn.Click += new System.EventHandler(this.Signup_btn_Click);
            // 
            // Signup_Password
            // 
            this.Signup_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_Password.Location = new System.Drawing.Point(714, 402);
            this.Signup_Password.Multiline = true;
            this.Signup_Password.Name = "Signup_Password";
            this.Signup_Password.Size = new System.Drawing.Size(671, 46);
            this.Signup_Password.TabIndex = 5;
            this.Signup_Password.TextChanged += new System.EventHandler(this.Signup_Password_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(719, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(719, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(706, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Get Started";
            // 
            // Signup_Username
            // 
            this.Signup_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_Username.Location = new System.Drawing.Point(714, 291);
            this.Signup_Username.Multiline = true;
            this.Signup_Username.Name = "Signup_Username";
            this.Signup_Username.Size = new System.Drawing.Size(671, 46);
            this.Signup_Username.TabIndex = 1;
            this.Signup_Username.TextChanged += new System.EventHandler(this.Signup_Username_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 713);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "FrmSignup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSignup";
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
        private System.Windows.Forms.Label Signup_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Signup_Showpassword;
        private System.Windows.Forms.Button Signup_btn;
        private System.Windows.Forms.TextBox Signup_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Signup_Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Signup_Emailid;
        private System.Windows.Forms.Label Signup_close;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}