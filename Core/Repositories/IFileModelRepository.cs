using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Board.Persistence.Repositories
{
    public interface IFileModelRepository
    {
        public void AddImages(IEnumerable<IFormFile> fileModels, int id);
        //public List<FileModel> GetImages(string userId,int publicationId);
        public List<string> GetImages(string userId,int pubId);
        void RemovePicture(string userId, int id, int picNumber);
    }
}