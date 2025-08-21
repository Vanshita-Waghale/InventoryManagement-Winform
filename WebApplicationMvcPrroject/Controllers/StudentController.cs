using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMvcPrroject.Models;

namespace WebApplicationMvcPrroject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {


            StudentViewModel sObj1 = new StudentViewModel();
            sObj1.Name = "Bhumika";
            sObj1.City = "Jabalpur";
            sObj1.FirstName = "Ashika";
            sObj1.Department = "Admin";
            sObj.StudentList.Add(sObj1);

            sObj.StudentList.Add(new StudentViewModel() { Name = "Shivani ", City = "Pune" });
            sObj.StudentList.Add(new StudentViewModel() { Name = "Nidhi ", City = "Pune" });
            sObj.StudentList.Add(new StudentViewModel() { Name = "Darshana ", City = "Pune" });


            return View(sObj);
        }
        
    }
    }
