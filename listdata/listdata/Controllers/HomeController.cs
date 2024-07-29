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

        //public ActionResult About()
        //{
        //    var people = new List<Person>
        //    {
        //        new Person { FirstName = "Dhaval", LastName = "Sojitra",Age=25 },
        //        new Person { FirstName = "Keval", LastName = "Vadadoriya",Age=12 },
        //        new Person { FirstName = "Jaydeep", LastName = "Kakadiya",Age=30 },
        //        new Person { FirstName = "Divyaraj", LastName = "Ahir",Age=26 },
        //        new Person { FirstName = "Jimit", LastName = "Vasoya",Age=15 },
        //        new Person { FirstName = "Jay", LastName = "Khunt",Age=22 }
        //    };

        //    return View(people);
        //}
        private static readonly int PageSize = 5; // Number of records per page

        public ActionResult About(int page = 1)
        {
            // Get the list of people (this might be from a database in a real application)
            var people = GetPeople();

            // Calculate the total number of pages
            var totalPages = (int)Math.Ceiling(people.Count / (double)PageSize);

            // Get the records for the current page
            var pagedPeople = people
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Pass the paged data and pagination information to the view
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedPeople);
        }

        private List<Person> GetPeople()
        {
            // This method should return a list of people from your data source
            // For example purposes, a hardcoded list is used
            return new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 22 },
            new Person { FirstName = "Alice", LastName = "Johnson", Age = 30 },
            new Person { FirstName = "Bob", LastName = "Brown", Age = 27 },
            new Person { FirstName = "Charlie", LastName = "Davis", Age = 35 },
            new Person { FirstName = "David", LastName = "Wilson", Age = 29 },
            new Person { FirstName = "Eve", LastName = "Taylor", Age = 31 },
            new Person { FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 22 },
            new Person { FirstName = "Alice", LastName = "Johnson", Age = 30 },
            new Person { FirstName = "Bob", LastName = "Brown", Age = 27 },
            new Person { FirstName = "Charlie", LastName = "Davis", Age = 35 },
            new Person { FirstName = "David", LastName = "Wilson", Age = 29 },
            new Person { FirstName = "Eve", LastName = "Taylor", Age = 31 },
            new Person { FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 22 },
            new Person { FirstName = "Alice", LastName = "Johnson", Age = 30 },
            new Person { FirstName = "Bob", LastName = "Brown", Age = 27 },
            new Person { FirstName = "Charlie", LastName = "Davis", Age = 35 },
            new Person { FirstName = "David", LastName = "Wilson", Age = 29 },
            new Person { FirstName = "Eve", LastName = "Taylor", Age = 31 },
            new Person { FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 22 },
            new Person { FirstName = "Alice", LastName = "Johnson", Age = 30 },
            new Person { FirstName = "Bob", LastName = "Brown", Age = 27 },
            new Person { FirstName = "Charlie", LastName = "Davis", Age = 35 },
            new Person { FirstName = "David", LastName = "Wilson", Age = 29 },
            new Person { FirstName = "Eve", LastName = "Taylor", Age = 31 },
            new Person { FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 22 },
            new Person { FirstName = "Alice", LastName = "Johnson", Age = 30 },
            new Person { FirstName = "Bob", LastName = "Brown", Age = 27 },
            new Person { FirstName = "Charlie", LastName = "Davis", Age = 35 },
            new Person { FirstName = "David", LastName = "Wilson", Age = 29 },
            new Person { FirstName = "Eve", LastName = "Taylor", Age = 31 }
        };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}