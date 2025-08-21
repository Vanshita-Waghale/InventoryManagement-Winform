using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplicationNewApi.DB;
using WebApplicationNewApi.Models;

namespace WebApplicationNewApi.Controllers
{

    public class ServiceController : ApiController
    {
        [System.Web.Http.HttpPost]
        public List<string> GetNames()

        {

            List<string> names = new List<string>();

            names.Add("Amar");

            names.Add("Akbar");

            names.Add("Anthony");

            return names;

        }
               SchoolEntities db = new SchoolEntities();
               [System.Web.Http.HttpGet]
        public StudentViewModel StudentData()
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
            return sobj;
        }
        [System.Web.Http.HttpDelete]
        public bool DeleteStudent(int id)
        {
            var studentFound = db.Information.Where(x => x.id == id).FirstOrDefault();
            if (studentFound != null)
            {
                db.Information.Remove(studentFound);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [System.Web.Http.HttpPost]
        public int SaveStudent(StudentViewModel sobj)
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
                    return studentFound.id;
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
                return s.id;
            }
            return 0;
        }

    }
}

