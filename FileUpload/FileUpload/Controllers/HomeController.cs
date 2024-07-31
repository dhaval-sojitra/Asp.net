using System;
using System.Collections.Generic;
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
            
            
            //f.SaveAs(Server.MapPath("~") + filename);

            String filename = f.FileName;
            string newnm = Guid.NewGuid().ToString() + "_" + filename;
            f.SaveAs(Server.MapPath("~") + newnm);
            ViewBag.Message = "Your application description page.";

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