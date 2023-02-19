using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public void Add(Category category)
        //{
        //    _unitOfWork.Category.Add(category);
        //    _unitOfWork.Complete();
        //}

        //public void Delete(int id, string userId)
        //{
        //    _unitOfWork.Category.Delete(id, userId);
        //    _unitOfWork.Complete();

        //}



        public IEnumerable<Category> Get()
        {
            return _unitOfWork.Category.Get();
        }

        public Category Get(int id)
        {
            return _unitOfWork.Category.Get(id);
        }

        //public void Update(Category category)
        //{
        //    _unitOfWork.Category.Update(category);
        //    _unitOfWork.Complete();
        //}
    }
}
