using Board.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Publication> Publications { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<FileModel> FileModels { get; set; }

        int SaveChanges();
    }
}
