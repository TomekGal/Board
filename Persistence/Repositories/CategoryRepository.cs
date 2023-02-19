using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Board.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDbContext _context;

        public CategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        //public void Add(Category category)
        //{
        //    _context.Categories.Add(category);

        //}

        //public void Delete(int id, string userId)
        //{
        //    var categoryToDelete = _context.Categories.Single(x => x.Id == id && x.UserId == userId);

        //    _context.Categories.Remove(categoryToDelete);
        //}

        public IEnumerable<Category> Get()
        {
            var categories = _context.Categories;
                              



            return categories.OrderBy(x => x.Name).ToList();
        }

        public Category Get(int id)
        {
            var category = _context.Categories
                .Single(x => x.Id == id );
            return category;
        }

        //public void Update(Category category)
        //{
        //    var categoryToUpdate = _context.Categories.Single(x => x.Id == category.Id);

        //    categoryToUpdate.Name = category.Name;

        //}
    }
}
