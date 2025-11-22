using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoManWinform.Navigation
{
    public partial class FrmLogin : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        public FrmLogin()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            Login_Password.PasswordChar = '●';

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Register_Click(object sender, EventArgs e)
        {
            FrmSignup signup = new FrmSignup();
            signup.ShowDialog();

            // Bring login back to the front after signup closes
            this.Show();
        }

        private void Login_Username_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Login_Username, "");
        }

        private void Login_Password_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Login_Password, "");
        }

        private void Login_Showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (Login_Showpassword.Checked)
                Login_Password.PasswordChar = '\0';  // Show
            else
                Login_Password.PasswordChar = '●';  // Hide
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string username = Login_Username.Text.Trim();
            string password = Login_Password.Text.Trim();

            bool hasError = false;

            // Username validation (same pattern as signup)
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[A-Za-z][A-Za-z0-9_]{3,20}$"))
            {
                errorProvider1.SetError(Login_Username, "Enter a valid username.");
                hasError = true;
            }

            // Password required check
            if (string.IsNullOrWhiteSpace(password))
            {
                errorProvider1.SetError(Login_Password, "Password is required.");
                hasError = true;
            }

            if (hasError)
                return;

            // Database check
            string query = @"SELECT COUNT(*) 
                     FROM Users 
                     WHERE Username = @u AND PasswordHash = @p";

            object result = Commands.ExecuteScalar(
                query,
                new SqlParameter("@u", username),
                new SqlParameter("@p", password)
            );

            int count = result != null ? Convert.ToInt32(result) : 0;

            if (count == 1)
            {
                MessageBox.Show("Login successful!", "Success");

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                errorProvider1.SetError(Login_Username, "Invalid login credentials.");
                errorProvider1.SetError(Login_Password, "Invalid login credentials.");
            }

        }

        private void Login_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
