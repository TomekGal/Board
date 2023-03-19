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
        



        public IEnumerable<Category> Get()
        {
            return _unitOfWork.Category.Get();
        }

        public Category Get(int id)
        {
            return _unitOfWork.Category.Get(id);
        }

     
    }
}
