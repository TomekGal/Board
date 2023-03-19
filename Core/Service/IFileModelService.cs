using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Service
{
   public interface IFileModelService
    {
        public void AddImages(IEnumerable<IFormFile> fileModels, int id);
         //List<FileModel> GetImages( string userId, int publicationId);

        List<string> GetImages(string userId,int pubId);
        void RemovePicture(string userId, int id, int picNumber);

        public List<FileModel> IFileModelToFileModel(IEnumerable<IFormFile> IFileModels, int id);
        public void TempFile(List<string> filesList);
    }
}
