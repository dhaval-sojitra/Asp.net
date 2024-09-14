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

        // Static list to store user data temporarily
        private static readonly List<User> _users = new List<User>();

        // GET: Users/Registration
        public ActionResult Registration()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            // Retrieve form values
            var name = Request.Form["Name"];
            var phone = Request.Form["Phone"];
            var username = Request.Form["Username"];
            var password = Request.Form["Password"];
            var confirmPassword = Request.Form["ConfirmPassword"];

            // Create a new User object and populate it with form values
            var user = new User
            {
                Name = name,
                Phone = phone,
                Username = username,
                Password = password
            };

            // Check if passwords match
            if (password != confirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
            }

            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Add the new user to the static list
                _users.Add(user);

                // Redirect to Index or another action after successful registration
                return RedirectToAction("Index");
            }

            // If validation fails, return the view with the current model state
            return View("Registration", user);
        }

        // GET: Users/Index
        public ActionResult Index()
        {
            // Return a view displaying all registered users
            return View(_users);
        }
    }
}
