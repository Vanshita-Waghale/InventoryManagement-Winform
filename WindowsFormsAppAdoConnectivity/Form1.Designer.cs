namespace WindowsFormsAppAdoConnectivity
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.eMPLOYEEDataSet = new WindowsFormsAppAdoConnectivity.EMPLOYEEDataSet();
            this.eMPLOYEEDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.eMPLOYEEDataSet1 = new WindowsFormsAppAdoConnectivity.EMPLOYEEDataSet1();
            this.bonusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusTableAdapter = new WindowsFormsAppAdoConnectivity.EMPLOYEEDataSet1TableAdapters.BonusTableAdapter();
            this.wORKERREFIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bONUSAMOUNTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bONUSDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.eMPLOYEEDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // eMPLOYEEDataSet
            // 
            this.eMPLOYEEDataSet.DataSetName = "EMPLOYEEDataSet";
            this.eMPLOYEEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eMPLOYEEDataSetBindingSource
            // 
            this.eMPLOYEEDataSetBindingSource.DataSource = this.eMPLOYEEDataSet;
            this.eMPLOYEEDataSetBindingSource.Position = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wORKERREFIDDataGridViewTextBoxColumn,
            this.bONUSAMOUNTDataGridViewTextBoxColumn,
            this.bONUSDATEDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.bonusBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(123, 146);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(573, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // eMPLOYEEDataSet1
            // 
            this.eMPLOYEEDataSet1.DataSetName = "EMPLOYEEDataSet1";
            this.eMPLOYEEDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bonusBindingSource
            // 
            this.bonusBindingSource.DataMember = "Bonus";
            this.bonusBindingSource.DataSource = this.eMPLOYEEDataSet1;
            // 
            // bonusTableAdapter
            // 
            this.bonusTableAdapter.ClearBeforeFill = true;
            // 
            // wORKERREFIDDataGridViewTextBoxColumn
            // 
            this.wORKERREFIDDataGridViewTextBoxColumn.DataPropertyName = "WORKER_REF_ID";
            this.wORKERREFIDDataGridViewTextBoxColumn.HeaderText = "WORKER_REF_ID";
            this.wORKERREFIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.wORKERREFIDDataGridViewTextBoxColumn.Name = "wORKERREFIDDataGridViewTextBoxColumn";
            this.wORKERREFIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // bONUSAMOUNTDataGridViewTextBoxColumn
            // 
            this.bONUSAMOUNTDataGridViewTextBoxColumn.DataPropertyName = "BONUS_AMOUNT";
            this.bONUSAMOUNTDataGridViewTextBoxColumn.HeaderText = "BONUS_AMOUNT";
            this.bONUSAMOUNTDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bONUSAMOUNTDataGridViewTextBoxColumn.Name = "bONUSAMOUNTDataGridViewTextBoxColumn";
            this.bONUSAMOUNTDataGridViewTextBoxColumn.Width = 125;
            // 
            // bONUSDATEDataGridViewTextBoxColumn
            // 
            this.bONUSDATEDataGridViewTextBoxColumn.DataPropertyName = "BONUS_DATE";
            this.bONUSDATEDataGridViewTextBoxColumn.HeaderText = "BONUS_DATE";
            this.bONUSDATEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bONUSDATEDataGridViewTextBoxColumn.Name = "bONUSDATEDataGridViewTextBoxColumn";
            this.bONUSDATEDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEEDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource eMPLOYEEDataSetBindingSource;
        private EMPLOYEEDataSet eMPLOYEEDataSet;
        private System.Windows.Forms.DataGridView dataGridView2;
        private EMPLOYEEDataSet1 eMPLOYEEDataSet1;
        private System.Windows.Forms.BindingSource bonusBindingSource;
        private EMPLOYEEDataSet1TableAdapters.BonusTableAdapter bonusTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn wORKERREFIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bONUSAMOUNTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bONUSDATEDataGridViewTextBoxColumn;
    }
}

