using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21502987_HWA3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            if(files != null && files.ContentLength > 0)
            {
                var filename = Path.GetFileName(files.FileName);
                var path = "";
                if (Request["Answer"] == "Document")
                {
                    path = Path.Combine(Server.MapPath("~/Media/Documents/"), filename);
                    files.SaveAs(path);
                }
                else if (Request["Answer"] == "Image")
                {
                    path = Path.Combine(Server.MapPath("~/Media/Images/"), filename);
                    files.SaveAs(path);
                }

                else if (Request["Answer"] == "Video")
                {
                    path = Path.Combine(Server.MapPath("~/Media/Videos/"), filename);
                    files.SaveAs(path);
                }
            }
            return RedirectToAction("Index");

        }

        public ActionResult About()
        {
            return View();
        }
    }
}