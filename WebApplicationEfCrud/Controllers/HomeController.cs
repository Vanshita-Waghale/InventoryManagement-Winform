using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Xml.Linq;
using WebApplicationEfCrud.DB;
using WebApplicationEfCrud.Models;
using System.Security.Cryptography.X509Certificates;

namespace WebApplicationCollectionCrud.Controllers

{

    public class HomeController : Controller
    {
        SchoolEntities db = new SchoolEntities();
        // GET: Home
        public ActionResult Index()
        {
            //to get all students from the database table 
            //  var AllStudent = db.students.ToList();
            // to get single student record from db table
            //var SingleStudent = db.Information.Where(m => m.id == 1).FirstOrDefault();

            //to get all student records from the database on the basis on city name
            //var AllStudentCityBasis = db.Information.Where(m => m.city == "Nagpur").ToList();
            return View();

            //all the above three lines of code are known as LAMBDA EXPRESSION 
        }


        // GET: Home
        public ActionResult StudentData()
        {
            StudentViewModel sobj = new StudentViewModel();
            var AllStudent = db.Information.ToList();

            foreach (var row in AllStudent)
            {
                StudentViewModel sobj1 = new StudentViewModel();

                sobj1.id = Convert.ToInt32(row.id);
                sobj1.Name = row.Name.ToString();
                sobj1.Age = row.Age != 0 ? row.Age.ToString() : "0";
                sobj1.City = row.City.ToString();
                sobj.StudentList.Add(sobj1);
            }
            return View(sobj);
        }

        public ActionResult DeleteStudent(int id)
        {
            var studentFound = db.Information.Where(x => x.id == id).FirstOrDefault();
            if (studentFound != null)
            {
                db.Information.Remove(studentFound);
                db.SaveChanges();
            }
            return RedirectToAction("StudentData");
        }

        public ActionResult AddStudent(int id = 0)
        //optional parameter id=0
        {
            StudentViewModel sobj = new StudentViewModel();
            if (id > 0)
            {
                var studentFound = db.Information.Where(x => x.id == id).FirstOrDefault();
                if (studentFound != null)
                {

                    sobj.id = Convert.ToInt32(studentFound.id);
                    sobj.Name = studentFound.Name;
                    sobj.Age = studentFound.Age != 0 ? studentFound.Age.ToString() : "0";
                    sobj.City = studentFound.City;
                }
            }
            return View(sobj);
        }

        //sobj is view object and s is database object
        public ActionResult SaveStudent(StudentViewModel sobj)
        {
            if (sobj.id > 0)
            {
                //student is from DB
                //update data
                var studentFound = db.Information.Where(x => x.id == sobj.id).FirstOrDefault();
                if (studentFound != null)
                {
                    //if data found in db
                    studentFound.Name = sobj.Name;
                    studentFound.Age = !string.IsNullOrEmpty(sobj.Age) ? Convert.ToInt32(sobj.Age) : (int?)null;
                    studentFound.City = sobj.City;
                    db.SaveChanges();
                }
            }
            else
            {
                //add data 
                Information s = new Information();
                s.Name = sobj.Name;
                s.Age = !string.IsNullOrEmpty(sobj.Age) ? Convert.ToInt32(sobj.Age) : (int?)null;
                s.City = sobj.City;
                db.Information.Add(s);
                db.SaveChanges();

            }
            return RedirectToAction("StudentData");
        }
    }
}