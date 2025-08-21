using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLogin.Models;

namespace WebApplicationLogin.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost] // This attribute indicates that this method handles POST requests
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // Check if model state is valid
            {
                if (model.Username == "cdac" && model.Password == "12345")
                {
                    Session["UserName"] = model.Username; 
                    return RedirectToAction("Welcome"); // Redirect to Welcome 
                }
                ModelState.AddModelError("", "Invalid username or password"); 
            }
            return View(model); 
        }

        
        public ActionResult Logout()
        {
            Session.Clear(); // Clear the session
            return RedirectToAction("Login"); // Redirect to Login action
        }

        
        public ActionResult Welcome()
        {
            // Check if the session variable is set
            if (Session["UserName"] == null)
                return RedirectToAction("Login"); // Redirect to Login if session is null
            return View(); 
        }

        
        public ActionResult About()
        {
            return View(); // Render the About view
        }


        public ActionResult Contact()
        {
            return View();
        }
    }
}

