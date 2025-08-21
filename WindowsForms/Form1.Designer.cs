namespace WindowsForms
{
    partial class Form1
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
            this.txt_TypeName = new System.Windows.Forms.TextBox();
            this.txt_EnterName = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_TypeName
            // 
            this.txt_TypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TypeName.Location = new System.Drawing.Point(317, 38);
            this.txt_TypeName.Name = "txt_TypeName";
            this.txt_TypeName.Size = new System.Drawing.Size(214, 30);
            this.txt_TypeName.TabIndex = 0;
            // 
            // txt_EnterName
            // 
            this.txt_EnterName.AutoSize = true;
            this.txt_EnterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EnterName.Location = new System.Drawing.Point(29, 38);
            this.txt_EnterName.Name = "txt_EnterName";
            this.txt_EnterName.Size = new System.Drawing.Size(241, 32);
            this.txt_EnterName.TabIndex = 1;
            this.txt_EnterName.Text = "Enter your Name";
            this.txt_EnterName.Click += new System.EventHandler(this.txt_EnterName_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(314, 149);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(48, 24);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "label";
            this.lbl.Visible = false;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(317, 86);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(827, 253);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txt_EnterName);
            this.Controls.Add(this.txt_TypeName);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txt_TypeName;
        private System.Windows.Forms.Label txt_EnterName;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btn_Submit;
    }
}

