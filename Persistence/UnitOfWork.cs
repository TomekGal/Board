using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Repositories;
using Board.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
           
            Publication = new PublicationRepository(context);
            Category = new CategoryRepository(context);
            FileModel = new FileModelRepository(context);

        }

        public IPublicationRepository Publication { get; set; }
        public ICategoryRepository Category { get; set; }
        public IFileModelRepository FileModel { get; set; }


        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
