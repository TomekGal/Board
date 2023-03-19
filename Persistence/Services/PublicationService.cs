using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Service;
using Board.Core.ViewModels;
using System.Collections.Generic;


namespace Board.Persistence.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Publication> Get(string userId, string title = null, int categoryId = 0, bool isExecuted = false)
        {
            return _unitOfWork.Publication.Get(userId, title, categoryId,isExecuted);
        }

        public IEnumerable<Publication> GetAll(string title = null, int categoryId = 0)
        {
            return _unitOfWork.Publication.GetAll( title, categoryId);
        }

        public IEnumerable<Publication> GetAll()
        {
            return _unitOfWork.Publication.GetAll();
        }

        public Publication Get(int id, string userId)
        {
            return _unitOfWork.Publication.Get(id, userId);
        }

        public void Add(Publication publication)
        {
            _unitOfWork.Publication.Add(publication);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Publication.Delete(id, userId);
            _unitOfWork.Complete();
        }

       
       

        public void Update(PublicationViewModel viewModel)
        {
            _unitOfWork.Publication.Update(viewModel);
            _unitOfWork.Complete();
        }

        public void Publish(int id, string userId)
        {
            _unitOfWork.Publication.Publish( id, userId);
            _unitOfWork.Complete();
        }

        public void Remove(int id, string userId)
        {
            _unitOfWork.Publication.Remove(id, userId);
            _unitOfWork.Complete();
        }

        public Publication Get(int id)
        {
            return _unitOfWork.Publication.Get(id);
        }
    }
}
