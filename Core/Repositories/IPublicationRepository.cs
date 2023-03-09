using Board.Core.Models.Domains;
using Board.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Board.Core.Repositories
{
   public interface IPublicationRepository
    {
        IEnumerable<Publication> Get(string userId, string title = null, int categoryId=0 , bool IsExecuted = false);

        IEnumerable<Publication> GetAll();
        IEnumerable<Publication> GetAll(string title = null, int categoryId = 0);

        Publication Get(int id, string userId);

        void Add(Publication publication);

        void Update(PublicationViewModel viewModel);

        void Delete(int id, string userId);
        void Publish(int id, string userId);
        void Remove(int id, string userId);

    }
}
