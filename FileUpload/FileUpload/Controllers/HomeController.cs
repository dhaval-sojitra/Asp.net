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
                
                string fileExtension = Path.GetExtension(f.FileName).ToLower();

               
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

                
                if (allowedExtensions.Contains(fileExtension))
                {
                    
                    string filename = f.FileName;
                    string newnm = Guid.NewGuid().ToString() + "_" + filename;

                    
                    f.SaveAs(Path.Combine(Server.MapPath("~"), newnm));

                    ViewBag.Message = "File uploaded successfully.";
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