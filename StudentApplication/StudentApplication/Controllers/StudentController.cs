using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentModel s = new StudentModel();
            s.id = 1;
            s.name = "Dhaval Sojitra";
            s.city = "Surat";

            List<StudentModel> list = new List<StudentModel>
            {
                new StudentModel { id = 1, name = "Dhaval" ,city = "Surat"},
                new StudentModel { id = 2, name = "Keval" , city = "Surat" },
                new StudentModel { id = 3, name = "Jimit" , city = "Surat" },
                new StudentModel { id = 4, name = "Jaydeep" , city = "Ahemedabad" },
                new StudentModel { id = 5, name = "Divyaraj" , city = "Surat" }
            };
            ViewBag.model = list;
            return View();
        }
        public ActionResult About()
        {
            string[] name = { "Dhaval", "Keval", "Jimit", "Jaydeep", "Divyaraj" };
            ViewBag.name = name;
            return View();
        }
        public ActionResult Contect()
        {
            return View();
        }
    }
}