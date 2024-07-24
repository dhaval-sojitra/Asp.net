using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using formin.Models;

namespace formin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Student s = new Student();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student s)
        {
            return View(s);
        }


        public ActionResult About()
        {
            Student s = new Student();
            return View();
        }
        [HttpPost]
        public ActionResult About(Student s)
        {
            return View(s);
        }
    }
}