using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsControls_Part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start(); // Start the timer when the form loads
            //timer1.Enabled = true; 
            timer2.Start();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblResult.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            lblWatch.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker_Timer.Value = DateTime.Now;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblWatch.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
