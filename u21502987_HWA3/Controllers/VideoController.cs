using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21502987_HWA3.Models;
using System.IO;

namespace u21502987_HWA3.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            string[] FilePaths = Directory.GetFiles(Server.MapPath("~/Media/Videos"));
            List<FileModel> Files = new List<FileModel>();
            foreach(string FilePath in FilePaths)
            {
                Files.Add(new FileModel { FileName = Path.GetFileName(FilePath) });
            }
            return View(Files);
        }

        public FileResult DownloadFile(string FileName)
        {
            string FilePath = Server.MapPath("~/Media/Videos/") + FileName;
            byte[] Bytes = System.IO.File.ReadAllBytes(FilePath);
            return File(Bytes, "application/octet-stream", FileName);
        }

        public ActionResult DeleteFile(string FileName)
        {
            string Filepath = Server.MapPath("~/Media/Videos/") + FileName;
            byte[] Bytes = System.IO.File.ReadAllBytes(Filepath);
            System.IO.File.Delete(Filepath);
            return RedirectToAction("Index");

        }
    }
}