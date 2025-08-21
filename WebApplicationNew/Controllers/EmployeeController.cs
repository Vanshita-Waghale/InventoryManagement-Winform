using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationNew.Models;

namespace WebApplicationNew.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public ActionResult Index()
        {

            //StudentViewModel sobj = new StudentViewModel();
            EmployeeViewModel sobj = new EmployeeViewModel();
            
            sobj.FirstName = "Aarti";
            sobj.Department = "Admin";

            EmployeeViewModel sObj1 = new EmployeeViewModel();

            sObj1.FirstName = "Ashika";
            sObj1.Department = "Admin";

            sobj.EmployeeList.Add(sObj1);

            sobj.EmployeeList.Add(new EmployeeViewModel() { FirstName = "Maggi ", Department = "HR" });

            return View(sobj);
        }
        static SqlConnection con = new SqlConnection("Data Source=VICSHA; Database=EMPLOYEE; Integrated Security=True");
        public ActionResult EmployeeData()
        {
            EmployeeViewModel sObj = new EmployeeViewModel();
            con.Open();
            string query = "SELECT * FROM Worker";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);



            DataRow row;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                EmployeeViewModel sObj1 = new EmployeeViewModel();
                sObj1.id = Convert.ToInt32(row[0]);
                sObj1.FirstName = row[1].ToString();
                sObj1.Department = row[5].ToString();
                sObj.EmployeeList.Add(sObj1);



            }
            con.Close();

            return View(sObj);
        }

        public ActionResult AddEmployee(int id = 0)
        {
            EmployeeViewModel sObj = new EmployeeViewModel();
            if (id > 0)
            {
                con.Open();
                string query = "SELECT * FROM Worker WHERE id = " + id;
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row;
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                    sObj.id = Convert.ToInt32(row[0]);
                    sObj.FirstName = row[1].ToString();
                    sObj.Department = row[5].ToString();

                }
                con.Close();
            }
                return View(sObj);

        }
        public ActionResult SaveWorker(EmployeeViewModel sObj)
        {
            con.Open();
            string query = "";
            if (sObj.id > 0)
            {
                query = $"Update Worker set First_Name='{sObj.FirstName}', Department='{sObj.Department}' Where id= {sObj.id}";
            }
            else
            {
                query = $"Insert into Worker(First_Name,Department) values ('{sObj.FirstName}','{sObj.Department}')";
            }
             
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("EmployeeData");

        }
        public ActionResult DeleteWorker(int id)
        { 
            con.Open(); 
            string query = $"DELETE FROM Worker WHERE id = {id}";
            SqlCommand cmd = new SqlCommand(query, con); 
            cmd.ExecuteNonQuery(); 
            con.Close(); 
            return RedirectToAction("EmployeeData"); 
        }

    }
}

