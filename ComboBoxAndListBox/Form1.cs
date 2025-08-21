using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComboBoxAndListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum eChoice
        {
            //enum mai koi bhi integer value can be cast to enum type (datatype
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Divide = 3
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int Arg1 = 0;
            int.TryParse(txtArg1.Text, out Arg1);
            //It is pass by reference — because of the out keyword.
            //-In C#, parameters are passed by value by default.
            //- But when you use out or ref, you're explicitly telling the compiler to pass the variable by reference.
            //- This means the method can modify the original variable.
            int Arg2 = 0;
            int.TryParse(txtArg2.Text, out Arg2);

            int Result = 0;

            //switch (cmbChoice.Text)
            //{
            //    case "1-Add":
            //        Result = Arg1 + Arg2;
            //        break;
            //    case "2-Subtract":
            //        Result = Arg1 - Arg2;
            //        break;
            //    case "3-Multiply":
            //        Result = Arg1 * Arg2;
            //        break;
            //    case "4-Divide":
            //        Result = Arg1 / Arg2;
            //        break;
            //}



            //switch (cmbChoice.SelectedIndex)
            //{
            //    case 0://Add
            //        Result = Arg1 + Arg2;
            //        break;
            //    case 1://Subtract
            //        Result = Arg1 - Arg2;
            //        break;
            //    case 2://Multiply
            //        Result = Arg1 * Arg2;
            //        break;
            //    case 3: //Divide
            //        if (Arg2 != 0)
            //            Result = Arg1 / Arg2;
            //        else
            //            MessageBox.Show("Cannot divide by zero.");
            //        break;
            //    default:
            //        MessageBox.Show("Please select a valid operation.");
            //        return; // Exit the method if no valid operation is selected
            //}
            //txtResult.Text = Result.ToString();



            eChoice myChoice = (eChoice)cmbChoice.SelectedIndex;
            // Cast the selected index to the enum type

            switch (myChoice)
            {
                case eChoice.Add:
                    Result = Arg1 + Arg2;
                    break;
                case eChoice.Subtract:
                    Result = Arg1 - Arg2;
                    break;
                case eChoice.Multiply:
                    Result = Arg1 * Arg2;
                    break;
                case eChoice.Divide:
                    if (Arg2 != 0)
                        Result = Arg1 / Arg2;
                    else
                        MessageBox.Show("Cannot divide by zero.");
                    break;
                default:
                    MessageBox.Show("Please select a valid operation.");
                    return; // Exit the method if no valid operation is selected
            }
            txtResult.Text = Result.ToString();
        }

        private void btnAddAverageArgument_Click(object sender, EventArgs e)
        {
            //Trim - if there is any whites space after and before text it removes it.
            //TrimEnd - if there is any whites space after text it removes it.
            //TrimStart - if there is any whites space before text it removes it.
            //if (txtAverageArgument.Text != null &&
            //    txtAverageArgument.Text.Trim() != string.Empty
            //    && txtAverageArgument.Text.Trim() != "")
            //{

            //}

            if (!String.IsNullOrWhiteSpace(txtAverageArgument.Text))
            {
                lstbAverage.Items.Add(txtAverageArgument.Text);
                CalculateAverage(); // Call the method to calculate the average
                txtAverageArgument.Text = "";
            }

            //string averageText is ThreadExceptionDialog function which returns somthing

            void CalculateAverage() //made an method
                                    //method can also return the value how it returns 
            {
                int Sum = 0;
                for (int i = 0; i < lstbAverage.Items.Count; i = i + 1)
                {
                    int arg = 0;
                    int.TryParse(lstbAverage.Items[i].ToString(), out arg);
                    
                    Sum += arg;
                }
                txtAverage.Text = (Sum / lstbAverage.Items.Count).ToString();
            }
        }
    }
}


