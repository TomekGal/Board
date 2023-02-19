using Board.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();

        Category Get(int id);
        //void Add(Category category);

        //void Update(Category category);

        //void Delete(int id, string userId);

    }
}
