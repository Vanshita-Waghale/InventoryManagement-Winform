using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private object textName;

        public Form1()
        {
            InitializeComponent();
        }

        private void txt_EnterName_Click(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl.Text = "Welcome " + txt_TypeName.Text;
            lbl.Visible = true;
        }
    }
}
