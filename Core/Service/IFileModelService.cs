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

    }
}
