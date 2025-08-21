namespace ComboBoxAndListBox
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
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChoice = new System.Windows.Forms.ComboBox();
            this.txtArg1 = new System.Windows.Forms.TextBox();
            this.txtArg2 = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lstbAverage = new System.Windows.Forms.ListBox();
            this.txtAverageArgument = new System.Windows.Forms.TextBox();
            this.btnAddAverageArgument = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Argument1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Argument2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Result";
            // 
            // cmbChoice
            // 
            this.cmbChoice.FormattingEnabled = true;
            this.cmbChoice.Items.AddRange(new object[] {
            "1-Add",
            "2-Subtract",
            "3-Multiply",
            "4-Divide"});
            this.cmbChoice.Location = new System.Drawing.Point(146, 58);
            this.cmbChoice.Name = "cmbChoice";
            this.cmbChoice.Size = new System.Drawing.Size(121, 24);
            this.cmbChoice.TabIndex = 4;
            // 
            // txtArg1
            // 
            this.txtArg1.Location = new System.Drawing.Point(146, 114);
            this.txtArg1.Name = "txtArg1";
            this.txtArg1.Size = new System.Drawing.Size(100, 22);
            this.txtArg1.TabIndex = 5;
            // 
            // txtArg2
            // 
            this.txtArg2.Location = new System.Drawing.Point(146, 158);
            this.txtArg2.Name = "txtArg2";
            this.txtArg2.Size = new System.Drawing.Size(100, 22);
            this.txtArg2.TabIndex = 6;
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.Location = new System.Drawing.Point(146, 252);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 22);
            this.txtResult.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Please enter number";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(146, 210);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lstbAverage
            // 
            this.lstbAverage.FormattingEnabled = true;
            this.lstbAverage.ItemHeight = 16;
            this.lstbAverage.Location = new System.Drawing.Point(370, 138);
            this.lstbAverage.Name = "lstbAverage";
            this.lstbAverage.Size = new System.Drawing.Size(235, 116);
            this.lstbAverage.TabIndex = 10;
            // 
            // txtAverageArgument
            // 
            this.txtAverageArgument.Location = new System.Drawing.Point(505, 58);
            this.txtAverageArgument.Name = "txtAverageArgument";
            this.txtAverageArgument.Size = new System.Drawing.Size(100, 22);
            this.txtAverageArgument.TabIndex = 11;
            // 
            // btnAddAverageArgument
            // 
            this.btnAddAverageArgument.Location = new System.Drawing.Point(505, 87);
            this.btnAddAverageArgument.Name = "btnAddAverageArgument";
            this.btnAddAverageArgument.Size = new System.Drawing.Size(75, 23);
            this.btnAddAverageArgument.TabIndex = 12;
            this.btnAddAverageArgument.Text = "Add";
            this.btnAddAverageArgument.UseVisualStyleBackColor = true;
            this.btnAddAverageArgument.Click += new System.EventHandler(this.btnAddAverageArgument_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Average";
            // 
            // txtAverage
            // 
            this.txtAverage.Location = new System.Drawing.Point(453, 261);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(152, 22);
            this.txtAverage.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAverage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddAverageArgument);
            this.Controls.Add(this.txtAverageArgument);
            this.Controls.Add(this.lstbAverage);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtArg2);
            this.Controls.Add(this.txtArg1);
            this.Controls.Add(this.cmbChoice);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbChoice;
        private System.Windows.Forms.TextBox txtArg1;
        private System.Windows.Forms.TextBox txtArg2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ListBox lstbAverage;
        private System.Windows.Forms.TextBox txtAverageArgument;
        private System.Windows.Forms.Button btnAddAverageArgument;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAverage;
    }
}

