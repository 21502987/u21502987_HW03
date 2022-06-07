using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21502987_HWA3.Models;
using System.IO;

namespace u21502987_HWA3.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            string[] FilePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));
            List<FileModel> Files = new List<FileModel>();
            foreach (string filepath in FilePaths)
            {
                Files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(Files);
        }

        public FileResult DownloadFile(string FileName)
        {
            string Filepath = Server.MapPath("~/Media/Images/") + FileName;
            byte[] Bytes = System.IO.File.ReadAllBytes(Filepath);
            return File(Bytes, "application/octet-stream", FileName);
        }

        public ActionResult DeleteFile(string FileName)
        {
            string FilePath = Server.MapPath("~/Media/Images/") + FileName;
            byte[] bytes = System.IO.File.ReadAllBytes(FilePath);

            System.IO.File.Delete(FilePath);

            return RedirectToAction("Index");
        }
    }
}