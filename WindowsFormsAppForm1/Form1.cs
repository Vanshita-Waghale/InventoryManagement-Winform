using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    int result = Convert.ToInt32(button1.Text) + Convert.ToInt32(textBox1.Text);
        //    textBox3.Text = result.ToString();

        //}

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    int result = Convert.ToInt32(button1.Text) - Convert.ToInt32(textBox1.Text);
        //    textBox3.Text = result.ToString();
        //}

        private void button2_Click(object sender, EventArgs e)
        {

            int result = Convert.ToInt32(textBox1_Text) + Convert.ToInt32(textBox2_Text);
            textBox3.Text = result.ToString();
        }
    }
}
