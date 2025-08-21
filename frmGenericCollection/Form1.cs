using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmGenericCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  // ✅ Only call it here


            #region Array Example
            //private void Form1_Load(object sender, EventArgs e)
            //{
            //    int[] myArray = new int[4] { 40, 24, 30, 40};

            //    for (int i = 0; i < myArray.Length; i++)
            //    {
            //        //textBox2.Text += "Age " + i + ": " + myArray[i] + "\r\n";
            //        textBox2.Text += $"Age {i}: {myArray[i]}\r\n"; // Using string interpolation
            //    }
            //    string[] myArry = new string[4] { "Hello", "GOOD", "Evening", "Everyone"};
            //    for (int i = 0; i < myArray.Length; i++)
            //    {
            //        textBox2.Text += $"Age {i}: {myArry[i]}\r\n";

            //    }


            //    textBox3.Text = "C:\\temp";
            //}
            #endregion
            #region List Example
            //int[] myArray = new int[4] { 40, 24, 30, 40 };

            List<int> mylist = new List<int> { 41, 24, 19, 50 };

            //List<int> mylist = new List<int>(4);
            //mylist[0]=41;
            //mylist[1]=24;
            //mylist[2]=19;
            //mylist[3]=50;

            //List<int> mylist = new List<int>();
            //mylist.Add(41);
            //mylist.Add(24);
            //mylist.Add(19);
            //mylist.Add(50);

            foreach (int r in mylist)
            {
                textBox2.Text += $"Value: {r}\r\n"; // Using string interpolation
            }
        }
            //for (int i = 0; i < mylist.Count; i++)
            //{
            //    textBox2.Text += $"Value {i}: {mylist[i]}\r\n";
            //}
private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    #endregion

}


// Topics Covered:
// - Generic Collection: Array and List
// - for loop
// - Escape characters like \r\n
// - Special characters in string