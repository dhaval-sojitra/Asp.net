using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string searchText = "")
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                // Filter students based on searchText
                var students = db.Students.ToList().Where(s => s.fname.Contains(searchText) || s.lname.Contains(searchText)); ;
                
                List<Student> std = students.ToList();
                return View(std);
            }
        }

        public ActionResult Delete(int id)
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                Student student = db.Students.Find(id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteSelected(int[] selectedIds)
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                if (selectedIds != null)
                {
                    foreach (int id in selectedIds)
                    {
                        Student student = db.Students.Find(id);
                        if (student != null)
                        {
                            db.Students.Remove(student);
                        }
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Insert(int id = 0, string mode = "")
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                Student student = new Student();
                if (id != 0)
                {
                    student = db.Students.Find(id);
                }
                else
                {
                    student = new Student();
                }
                ViewBag.mode = mode;
                ViewBag.id = id;

                return View(student);
            }
        }

        [HttpPost]
        public ActionResult InsertPost(Student s)
        {
            using (MyDBEntities db = new MyDBEntities())
            {
                string mode = Request["mode"];
                int id = Convert.ToInt32(Request["id"]);

                if (mode == "E")
                {
                    Student onestudent = db.Students.Find(id);
                    if (onestudent != null)
                    {
                        onestudent.fname = s.fname;
                        onestudent.lname = s.lname;
                        onestudent.city = s.city;
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.Students.Add(s);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
