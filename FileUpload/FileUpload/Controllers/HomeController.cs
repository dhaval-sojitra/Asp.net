using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Fileupload()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Fileupload(HttpPostedFileBase f)
        {


            ////f.SaveAs(Server.MapPath("~") + filename);

            //String filename = f.FileName;
            //string newnm = Guid.NewGuid().ToString() + "_" + filename;
            //f.SaveAs(Server.MapPath("~") + newnm);
            //ViewBag.Message = "Your application description page.";

            //return View();

            if (f != null && f.ContentLength > 0)
            {
                // Get the file extension
                string fileExtension = Path.GetExtension(f.FileName).ToLower();

                // Define allowed file extensions
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                // Check if the file extension is valid
                if (allowedExtensions.Contains(fileExtension))
                {
                    // Generate a unique filename
                    string filename = f.FileName;
                    string newnm = Guid.NewGuid().ToString() + "_" + filename;

                    // Define the file path
                    string filePath = Path.Combine(Server.MapPath("~/Uploads/"), newnm);

                    // Ensure the directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Save the file
                    f.SaveAs(filePath);

                    // Set the message and file path in ViewBag
                    ViewBag.Message = "File uploaded successfully.";
                    ViewBag.FilePath = Url.Content("~/Uploads/" + newnm);
                }
                else
                {
                    ViewBag.Message = "Only jpg and png files are allowed.";
                }
            }
            else
            {
                ViewBag.Message = "No file selected.";
            }

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}