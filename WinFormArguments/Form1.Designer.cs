namespace WinFormArguments
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Argument1 = new System.Windows.Forms.TextBox();
            this.Argument2 = new System.Windows.Forms.TextBox();
            this.buttonADD = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Argument and Add Two Numbers ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Argument 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Argument 2";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Argument1
            // 
            this.Argument1.Location = new System.Drawing.Point(220, 128);
            this.Argument1.Name = "Argument1";
            this.Argument1.Size = new System.Drawing.Size(100, 22);
            this.Argument1.TabIndex = 3;
            // 
            // Argument2
            // 
            this.Argument2.Location = new System.Drawing.Point(220, 194);
            this.Argument2.Name = "Argument2";
            this.Argument2.Size = new System.Drawing.Size(100, 22);
            this.Argument2.TabIndex = 4;
            this.Argument2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(220, 254);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 23);
            this.buttonADD.TabIndex = 5;
            this.buttonADD.Text = "ADD";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Result";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(220, 295);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(100, 22);
            this.Result.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.Argument2);
            this.Controls.Add(this.Argument1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Argument1;
        private System.Windows.Forms.TextBox Argument2;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Result;
    }
}

