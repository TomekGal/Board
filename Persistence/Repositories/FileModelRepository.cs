using Board.Core;
using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Board.Persistence.Repositories
{
   
    public class FileModelRepository : IFileModelRepository
    {
        private  IApplicationDbContext _context;
        private IWebHostEnvironment _hostingEnviroment;
      
        public FileModelRepository(IApplicationDbContext context, IWebHostEnvironment hostingEnviroment)
        {
            _context = context;
            _hostingEnviroment = hostingEnviroment;

        }

        public void TempFile(List<string> filesList)
        {
            string FilePath = Path.Combine(_hostingEnviroment.WebRootPath, "Temp");
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            foreach (var file in filesList)
            {
                var tempfile = File.Create(FilePath);
                using (FileStream fs = tempfile)
                {
                    
                }
            }
        }

        public List<FileModel> IFileModelToFileModel(IEnumerable<IFormFile> IFileModels, int id)
        {
            var FileModels = new List<FileModel>();

            if (IFileModels != null)
            {


                foreach (var image in IFileModels)
                {
                    if (image.Length > 0)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        image.CopyTo(memoryStream);
                        _ = memoryStream.ToArray();
                        var FileModel = new FileModel
                        {
                            FileName = Path.GetFileName(image.FileName),
                            FileType = Path.GetExtension(image.FileName),
                            PublicationId = id,
                            FilePath = Path.GetDirectoryName(image.FileName),
                            DataFiles = memoryStream.ToArray()

                        };
                        FileModels.Add(FileModel);
                    }

                }

            }
            return FileModels;
        }

        public void AddImages(IEnumerable<IFormFile> fileModels, int id)
        {
            if (fileModels != null)
            {


                foreach (var image in fileModels)
                {
                    if (image.Length > 0)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        image.CopyTo(memoryStream);
                        _ = memoryStream.ToArray();
                        var fileModel = new FileModel
                        {
                            FileName = Path.GetFileName(image.FileName),
                            FileType = Path.GetExtension(image.FileName),
                            PublicationId = id,
                            FilePath = Path.GetDirectoryName(image.FileName),
                            DataFiles = memoryStream.ToArray()

                        };
                        _context.FileModels.Add(fileModel);
                    }

                }
            }
        }
        public List<string> GetImages( string userId, int pubId)
        {
            var FilesList = new List<string>();
             var Images = _context.FileModels
                            .Where(x =>  x.Publication.UserId==userId && x.PublicationId==pubId).ToArray();

            foreach (var image in Images)
            {
              
                var myImageBase64 = Convert.ToBase64String(image.DataFiles);
                FilesList.Add(myImageBase64);

            }
           

            return FilesList;
        }

        public void RemovePicture(string userId, int id, int picNumber)
        {
           
            var ImagesFromDB = _context.FileModels
                            .Where(x => x.Publication.UserId == userId && x.PublicationId == id).ToArray();

            var ImageToRemove = ImagesFromDB[picNumber];
            try
            {
               
                _context.FileModels.Remove(ImageToRemove);

                _context.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
