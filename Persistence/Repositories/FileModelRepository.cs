using Board.Core;
using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Board.Persistence.Repositories
{
    public class FileModelRepository : IFileModelRepository
    {
        private readonly IApplicationDbContext _context;
        

        public FileModelRepository(IApplicationDbContext context)
        {
            _context = context;
           
        }

        public void AddImages(IEnumerable<IFormFile> fileModels, int id)
        {
            foreach (var image in fileModels)
            {
                if (image.Length>0)
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

        
    }
}
