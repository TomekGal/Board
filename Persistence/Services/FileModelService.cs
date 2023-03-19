using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Service;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Board.Persistence.Services
{
    public class FileModelService : IFileModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FileModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddImages(IEnumerable<IFormFile> fileModels, int id)
        {
            _unitOfWork.FileModel.AddImages(fileModels, id);
            _unitOfWork.Complete();
        }

        
        public List<string> GetImages(string userId, int pubId)
        {
            return _unitOfWork.FileModel.GetImages(userId, pubId);

        }

        public List<FileModel> IFileModelToFileModel(IEnumerable<IFormFile> IFileModels, int id)
        {
            return _unitOfWork.FileModel.IFileModelToFileModel(IFileModels, id);
        }

        public void RemovePicture(string userId, int id, int picNumber)
        {
             _unitOfWork.FileModel.RemovePicture(userId,id,picNumber);
        }

        public void TempFile(List<string> filesList)
        {
            _unitOfWork.FileModel.TempFile(filesList);
        }
    }
}
