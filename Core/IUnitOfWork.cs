using Board.Core.Repositories;
using Board.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Board.Core
{
    public interface IUnitOfWork
    {
        IPublicationRepository Publication { get; }

        ICategoryRepository Category { get; set; }

        IFileModelRepository FileModel { get; set; }

        void Complete();
    }
}
