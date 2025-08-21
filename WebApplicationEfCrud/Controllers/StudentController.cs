using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationEfCrud.DB;

namespace WebApplicationEfCrud.Controllers
{
    public class StudentController : Controller

    {
        SchoolEntities db = new SchoolEntities();
        // GET: Student
        public ActionResult Index()

        {
            //Lambda Expressions
            //var SingleRecord = db.Information.FirstOrDefault(x => x.id == 5);
            //var FirstIndoreCityRecord = db.Information.FirstOrDefault(x => x.City == "Indore");
            //var IndoreCityRecords = db.Information.Where(x => x.City == "Nagpur").ToList();
            //var PuneCityRecords = db.Information.Where(x => x.City == "Pune").ToList();
            //var StudentLiveInIndoreAndNameIsStudent5 = db.Information.Where(x => x.City == "Indore" && x.Name == "Shivani").ToList();
            //var StudentLiveInPuneAndNameIsStudent5 = db.Information.Where(x => x.City == "Nagpur" && x.Name == "Darshna").ToList();
            //var NameContainsUser = db.Information.Where(x => x.Name.Contains("User")).ToList();
            //var NameContainsA = db.Information.Where(x => x.Name.Contains("S")).ToList();
            //var IndoreCityRecordOrderByDesc = db.Information.Where(x => x.City == "Nagpur").OrderByDescending(y => y.id).ToList();
            //var IndoreCityRecordOrderByDescFirstOne = db.Information.Where(x => x.City == "Nagpur").OrderByDescending(y => y.id).FirstOrDefault();
            
            //// Take & Skip (example: used in pagination)
            var page1 = db.Information.OrderBy(y => y.id).ToList()

                .Skip(0 * 3).Take(3).ToList();

            var page2 = db.Information.OrderBy(y => y.id).ToList()

                .Skip(1 * 3).Take(3).ToList();

            var page3 = db.Information.OrderBy(y => y.id).ToList()

                .Skip(2 * 3).Take(3).ToList();

            return View();

        }

        public ActionResult HomePage()
        {
            ViewData["IndexPageMessage"] = "Hello, Amar!";
            ViewData["IntegerMessageCdac"] = 101;

            Session["UserName"] = "Cdac User";

            List<string> Fruitnames = new List<string>();
            Fruitnames.Add("Mango");
            Fruitnames.Add("Orange");
            Fruitnames.Add("Apple");
            Fruitnames.Add("Banana");
            Fruitnames.Add("Grapes");
            Fruitnames.Add("Papaya");
            Fruitnames.Add("Blueberry");
            Fruitnames.Add("Pinnapple");
            Fruitnames.Add("Cherry");

            ViewData["Fruits"] = Fruitnames;

            TempData["Welcome"] = "Hello, Team! Welcome...";

            return View();
        }

        public ActionResult AboutPage()
        {
            List<string> Fruitnames = new List<string>();
            Fruitnames.Add("Mango");
            Fruitnames.Add("Orange");
            Fruitnames.Add("Apple");
            Fruitnames.Add("Banana");
            Fruitnames.Add("Grapes");
            Fruitnames.Add("Papaya");
            Fruitnames.Add("Blueberry");
            Fruitnames.Add("Pinnapple");
            Fruitnames.Add("Cherry");

            ViewBag.Username = "Amar";
            ViewBag.Fruits = Fruitnames;

            return View();
        }

    }
}

  