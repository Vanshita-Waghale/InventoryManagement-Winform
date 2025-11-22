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
using MangoMaan.DAL;

namespace MangoManWinform.Navigation
{
    public partial class FrmSignup : Form
    {
        MangoMaan.DAL.CommonCommands Commands;
        public FrmSignup()
        {
            InitializeComponent();
            Commands = new MangoMaan.DAL.CommonCommands();
            errorProvider1.Clear();
            Signup_Password.PasswordChar = '●';
        }

        private void Signup_login_Click(object sender, EventArgs e)
        {
            FrmLogin lform = new FrmLogin();
            lform.ShowDialog();
            this.Hide();
        }

        private void Signup_Emailid_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Signup_Emailid, "");
        }

        private void Signup_Username_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Signup_Username, "");
        }

        private void Signup_Password_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(Signup_Password, "");
        }

        private void Signup_Showpassword_CheckedChanged(object sender, EventArgs e)
        {
            
            if (Signup_Showpassword.Checked)
                Signup_Password.PasswordChar = '\0';  // Show
            else
                Signup_Password.PasswordChar = '●';  // Hide
        }

        private void Signup_btn_Click(object sender, EventArgs e)
        {
         
            errorProvider1.Clear();

            string username = Signup_Username.Text.Trim();
            string email = Signup_Emailid.Text.Trim();
            string password = Signup_Password.Text.Trim();

            bool hasError = false;

            // Username rule: letters, numbers, underscores, starts with a letter
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[A-Za-z][A-Za-z0-9_]{3,20}$"))
            {
                errorProvider1.SetError(Signup_Username, "Username must start with a letter and contain 4–20 valid characters.");
                hasError = true;
            }

            // Email rule: basic format
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(Signup_Emailid, "Enter a valid email address.");
                hasError = true;
            }

            // Password rule: uppercase + lowercase + digit + special + 8 chars
            if (!System.Text.RegularExpressions.Regex.IsMatch(password,
                @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&#]).{8,}$"))
            {
                errorProvider1.SetError(Signup_Password,
                    "Password must have 8+ characters with uppercase, lowercase, number, and special character.");
                hasError = true;
            }

            if (hasError)
                return;

            // Check if username exists
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @u";
            object existsObj = Commands.ExecuteScalar(checkQuery, new SqlParameter("@u", username));
            int exists = existsObj != null ? Convert.ToInt32(existsObj) : 0;

            if (exists > 0)
            {
                errorProvider1.SetError(Signup_Username, "Username already exists.");
                return;
            }

            // Insert user
            string insertQuery = @"INSERT INTO Users (Username, PasswordHash, Email) 
                           VALUES (@u, @p, @e)";

            int rows = Commands.ExecuteNonQuery(
                insertQuery,
                new SqlParameter("@u", username),
                new SqlParameter("@p", password),
                new SqlParameter("@e", email)
            );

            if (rows > 0)
            {
                MessageBox.Show("Registration successful!");
                this.Hide();
                FrmLogin login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.Close(); // user logged in successfully
                }
                else
                {
                    this.Show(); // if login cancelled
                }


                // Clear fields after success (optional but professional)
                Signup_Username.Clear();
                Signup_Emailid.Clear();
                Signup_Password.Clear();
            }
            else
            {
                MessageBox.Show("Registration failed.");
            }
        }

        private void Signup_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


