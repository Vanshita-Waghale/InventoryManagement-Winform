using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormArguments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                // Read values from the textboxes
                double num1 = Convert.ToDouble(Argument1.Text);
                double num2 = Convert.ToDouble(Argument2.Text);

                // Perform addition
                double sum = num1 + num2;

                // Display result
                Result.Text = sum.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values in both fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
