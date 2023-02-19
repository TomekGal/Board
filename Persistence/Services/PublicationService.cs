using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Service;
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

       
       

        public void Update(Publication publication)
        {
            _unitOfWork.Publication.Update(publication);
            _unitOfWork.Complete();
        }

        public void Publish(int id, string userId)
        {
            _unitOfWork.Publication.Publish( id, userId);
            _unitOfWork.Complete();
        }

       
    }
}
