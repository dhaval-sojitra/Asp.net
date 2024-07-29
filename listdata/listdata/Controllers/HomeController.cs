using listdata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace listdata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var people = new List<Person>
            {
                new Person { FirstName = "Dhaval", LastName = "Sojitra",Age=21 },
                new Person { FirstName = "Keval", LastName = "Vadadoriya",Age=12 },
                new Person { FirstName = "Jaydeep", LastName = "Kakadiya",Age=20 },
                new Person { FirstName = "Divyaraj", LastName = "Ahir",Age=21 },
                new Person { FirstName = "Jimit", LastName = "Vasoya",Age=15 },
                new Person { FirstName = "Jay", LastName = "Khunt",Age=22 }
            };

            return View(people);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}