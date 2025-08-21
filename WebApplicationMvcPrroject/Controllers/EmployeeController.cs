using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMvcPrroject.Models;

namespace WebApplicationMvcPrroject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeIndex()
        {

            //StudentViewModel sobj = new StudentViewModel();
            EmployeeViewModel sobj= new EmployeeViewModel();
            sobj.FirstName= "Aarti";
            sobj.Department = "Admin";

            EmployeeViewModel sObj1 = new EmployeeViewModel();
            
            sObj1.FirstName = "Ashika";
            sObj1.Department = "Admin";

            sobj.EmployeeList.Add(sObj1);

            sobj.EmployeeList.Add(new EmployeeViewModel() { FirstName = "Maggi ", Department = "HR" });
            
            return View(sObj);
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

                sObj1.FirstName = row[1].ToString();
                sObj1.Department = row[5].ToString();
                sObj.EmployeeList.Add(sObj1);



            }
            con.Close();

            return View(sObj);
        }

        public ActionResult AddEmployee()
        {
            EmployeeViewModel sObj = new EmployeeViewModel();

            return View(sObj);

        }
        public ActionResult SaveWorker(EmployeeViewModel sObj)
        {
            con.Open();
            string query = $"Insert into Worker(First_Name,Department) values ('{sObj.FirstName}','{sObj.Department}')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("EmployeeData");

        }
        public ActionResult DeleteWorker(int id)
        {
            con.Open();
            string query = $"Delete From Worker where id= " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("EmployeeData");

        }
    }
}
