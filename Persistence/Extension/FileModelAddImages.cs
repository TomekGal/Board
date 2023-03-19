using Board.Core;
using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Board.Persistence.Repositories
{
   public  class FileModelAddImages
    {

        public  List<FileModel> IFileModelToFileModel(IEnumerable<IFormFile> IFileModels, int id)
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
    }
}