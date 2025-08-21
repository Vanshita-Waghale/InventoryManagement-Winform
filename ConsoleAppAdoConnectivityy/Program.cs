using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsFormsAppAdoConnectivity
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //GetDataFromDB();
            //AddNewWorker();
            //Console.Read();

            //UpdateWorker();
            //GetDataFromDB();
            //Console.Read();

            //DeleteWorker();
            GetDataFromDB();
            Console.Read();
        }

        // Define a static SqlConnection with your connection string
        static SqlConnection con = new SqlConnection("Data Source=VICSHA; Database=EMPLOYEE; Integrated Security=True");

        public static void GetDataFromDB()
        {
            con.Open();
            string query = "SELECT * FROM Worker";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataColumn col;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                col = dt.Columns[i];
                Console.WriteLine(col.ToString());
            }

            Console.WriteLine();

            //DataRow row;

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    row = dt.Rows[i];
            //    Console.WriteLine(row[0].ToString() + "\t" + "\t"
            //        + row[1].ToString() + "\t" + "\t"
            //        + row[2].ToString() + "\t" + "\t"
            //        //+ row[3].ToString() + "\t" + "\t"


            //        );

            //    con.Close();
            //}

            // Print each row dynamically
            foreach (DataRow row in dt.Rows)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(row[j].ToString());
                    if (j < dt.Columns.Count - 1) // Add tab space between columns
                    {
                        Console.Write("\t\t");
                    }
                }
                Console.WriteLine(); // Move to the next line after each row
            }
        }

        //public static void AddNewWorker()
        //{
        //    con.Open();
        //    string query = "Insert into Worker(First_Name,Department) values ('Ram ','HR')";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        public static void AddNewWorker()
        {
            while (true)
            {
                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter Salary:");
                int salary = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Department:");
                string department = Console.ReadLine();

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

        public static void UpdateWorker()
        {
            con.Open();
            Console.WriteLine("");
            Console.Write("Enter Id to update worker record: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Department:");
            string department = Console.ReadLine();

            string query = "Update Worker set First_Name = '" + firstName + "', Last_Name='" + lastName + "', Salary= " + salary + ", Department= '" + department + "' Where id = "+id;
            //String query =$"Update Worker set Name"
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();


        }

        public static void DeleteWorker()
        {
            con.Open();
            Console.WriteLine("");
            Console.Write("Enter Id to delete worker record: ");
            int id = Convert.ToInt32(Console.ReadLine());

            

            String query = $"Delete from Worker where id= + {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();


        }

    }
}
                