using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        private string currentInput = "";
        private double result = 0;
        private string operation = "";
        private bool operationPending = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Evaluate()
        {
            if (operationPending)
            {
                double secondNumber = double.Parse(currentInput);
                switch (operation)
                {
                    case "+":
                        result += secondNumber;
                        break;
                    case "-":
                        result -= secondNumber;
                        break;
                    case "*":
                        result *= secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result /= secondNumber;
                        }
                        else
                        {
                            textBox1.Text = "Error";
                            return;
                        }
                        break;
                     }
                textBox1.Text = result.ToString();
                currentInput = result.ToString();
                operationPending = false;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBox1.Text = currentInput;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if there is a pending operation to complete before starting a new one
            if (operationPending)
            {
                Evaluate(); // Perform the previous calculation
            }

            // Validate the current input and safely convert it to a double
            // This ensures the input is neither empty nor invalid and avoids runtime errors
            if (!string.IsNullOrWhiteSpace(currentInput) && double.TryParse(currentInput, out double value))
            {
                result = value; // Store the valid input as the current result
            }
            else
            {
                currentInput = "0"; // Reset input to a default value if it's invalid
                result = 0;         // Avoid exceptions by setting result to zero
            }
            // Using Button.Text allows reusing this logic for other operators as well
            if (sender is Button button)
            {
                operation = button.Text; // Store different operation
            }

            // Prepare for the next input
            // Reset the input and flag the calculator that an operation is now pending
            currentInput = "";
            operationPending = true;

        }

        private void btndivide_Click(object sender, EventArgs e)
        {
            if (operationPending)
            {
                Evaluate();
            }

            if (!string.IsNullOrWhiteSpace(currentInput) && double.TryParse(currentInput, out double value))
            {
                result = value;
            }
            else
            {
                currentInput = "0";
                result = 0;
            }

            if (sender is Button button)
            {
                operation = button.Text;
            }

            currentInput = "";
            operationPending = true;

        }

        private void btnSubtract_Click(object sender, EventArgs e)
        { 
            if (operationPending)
            {
                Evaluate();
            }

            if (!string.IsNullOrWhiteSpace(currentInput) && double.TryParse(currentInput, out double value))
            {
                result = value;
            }
            else
            {
                currentInput = "0";
                result = 0;
            }

            if (sender is Button button)
            {
                operation = button.Text;
            }

            currentInput = "";
            operationPending = true;
       
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (operationPending)
            {
                Evaluate();
            }

            if (!string.IsNullOrWhiteSpace(currentInput) && double.TryParse(currentInput, out double value))
            {
                result = value;
            }
            else
            {
                currentInput = "0";
                result = 0;
            }

            if (sender is Button button)
            {
                operation = button.Text;
            }

            currentInput = "";
            operationPending = true;

        }

        private void equalResultbtn_Click(object sender, EventArgs e)
        {
            Evaluate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentInput = "";
            DialogResult = 0;
            operation = "";
            operationPending = false;
            textBox1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
