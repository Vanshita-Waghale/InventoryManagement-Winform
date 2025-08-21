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

namespace WindowsFormsAppCRUDoperation
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMPLOYEEDataSet2.Worker' table. You can move, or remove it, as needed.
            this.workerTableAdapter2.Fill(this.eMPLOYEEDataSet2.Worker);

            // TODO: This line of code loads data into the 'eMPLOYEEDataSet.Worker' table. You can move, or remove it, as needed.
            this.workerTableAdapter.Fill(this.eMPLOYEEDataSet.Worker);

        }
        static SqlConnection con = new SqlConnection("Data Source=VICSHA; Database=EMPLOYEE; Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            //this.workerTableAdapter.Fill(this.eMPLOYEEDataSet.Worker);
            this.workerTableAdapter.Fill(this.eMPLOYEEDataSet.Worker);

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {

                string firstName = textBox2.Text;
                string lastName = textBox3.Text;
                int salary = Convert.ToInt32(textBox4.Text);
                string department = textBox5.Text;

                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM Worker WHERE First_Name = '" + firstName + "' AND Last_Name = '" + lastName + "'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);


                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {

                    Console.WriteLine("The combination of First Name and Last Name already exists in the database. Please try again.");
                    con.Close();
                }
                else
                {

                    string query = "INSERT INTO Worker (First_Name, Last_Name, Salary, Department) VALUES ('" + firstName + "', '" + lastName + "'," + salary + ",'" + department + "')";
                    SqlCommand cmd = new SqlCommand(query, con);


                    cmd.ExecuteNonQuery();
                    Console.WriteLine("New worker added successfully.");


                    con.Close();
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            int id = Convert.ToInt32(textBox1.Text);
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            int salary = Convert.ToInt32(textBox4.Text);
            string department = textBox5.Text;


            string query = "Update Worker set First_Name = '" + firstName + "', Last_Name='" + lastName + "', Salary= " + salary + ", Department= '" + department + "' Where id = " + id;
            //String query =$"Update Worker set Name"
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Close();
            int id = Convert.ToInt32(textBox1.Text);
            String query=$"Delete from worker where id={id}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

       
        
    }
 }
