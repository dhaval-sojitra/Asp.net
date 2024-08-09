using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Models;

namespace Crud.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            MyDBEntities db = new MyDBEntities();
            List<Student> std = db.Students.ToList();
            return View(std);
        }
        public ActionResult Delete(int id)
        {
            MyDBEntities db = new MyDBEntities();
            Student std = db.Students.Find(id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Registration()
        {
            //MyDBEntities db = new MyDBEntities();
            //Student std = db.Students.Find(id);
            //List<Student> sdata = new List<Student> { std };
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {
            MyDBEntities db = new MyDBEntities();
            db.Students.Add(s);
            db.SaveChanges()
            return RedirectToAction("Index");
        }


    }
}