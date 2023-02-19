using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Board.Core.Repositories
{
   public interface IPublicationRepository
    {
        IEnumerable<Publication> Get(string userId, string title = null, int categoryId=0 , bool IsExecuted = false);


        Publication Get(int id, string userId);

        void Add(Publication publication);

        void Update(Publication publication);

        void Delete(int id, string userId);
        void Publish(int id, string userId);
        
    }
}
