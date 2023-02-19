using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Controllers
{
    public class FilesUploadController : Controller
    {
        private IWebHostEnvironment Environment;
        public FilesUploadController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult FilesUpload(Publication publication)
        {
           
            return View(publication);
        }
    

 
        [HttpPost]
        public IActionResult FilesUpload(List<IFormFile> postedFiles)
        {
            //string wwwPath = this.Environment.WebRootPath;
            //string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }

            return RedirectToAction("Publication","Publication");
        }
    }
}