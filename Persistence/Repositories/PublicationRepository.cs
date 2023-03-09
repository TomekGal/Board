using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Repositories;
using Board.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Board.Persistence.Repositories.FileModelRepository;

namespace Board.Persistence.Repositories
{
    public class PublicationRepository : IPublicationRepository 
    {
        private IApplicationDbContext _context;
      
       public PublicationRepository(IApplicationDbContext context )
        {
            _context = context;
            
        }

      
        public IEnumerable<Publication> Get(string userId, string title = null, int categoryId = 0, bool isExecuted=false)
        {
           
            if (isExecuted == true)
            {
                var publications = _context.Publications
               .Include(x => x.Category)
               .Where(x => x.UserId == userId && x.IsExecuted == isExecuted);

                if (categoryId != 0)
                    publications = publications.Where(x => x.CategoryId == categoryId);
                if (!string.IsNullOrWhiteSpace(title))
                    publications = publications.Where(x => x.Title.Contains(title));

                return publications.OrderBy(x => x.PublicationDate).ToList();
            }
            else
            {
                var publications = _context.Publications
                    .Include(x => x.Category)
                    .Where(x => x.UserId == userId);

                if (categoryId != 0)
                    publications = publications.Where(x => x.CategoryId == categoryId);
                if (!string.IsNullOrWhiteSpace(title))
                    publications = publications.Where(x => x.Title.Contains(title));

                return publications.OrderBy(x => x.PublicationDate).ToList();
            }
        }

        public IEnumerable<Publication> GetAll()
        {


            var publications = _context.Publications.Where(x => x.IsExecuted == true).ToList();
            //.Include(x => x.Category)
            //.Where(x => x.IsExecuted == true);


            return publications.OrderBy(x => x.PublicationDate).ToList();


        }
        public IEnumerable<Publication> GetAll(string title = null, int categoryId = 0)
        {


            var publications = _context.Publications
                              .Where(x=> x.IsExecuted == true);

            if (categoryId != 0)
                publications = publications.Where(x => x.CategoryId == categoryId);
            if (!string.IsNullOrWhiteSpace(title))
                publications = publications.Where(x => x.Title.Contains(title));

            return publications.OrderBy(x => x.PublicationDate).ToList();


        }
        public Publication Get(int id, string userId)
        {
            var publication = _context.Publications
              .Single(x => x.Id == id && x.UserId == userId);
            
            return publication;
        }
        public void Add(Publication publication)
        {
            publication.PublicationDate = DateTime.Now;
           
            _context.Publications.Add(publication);
        }

        public void Update(PublicationViewModel viewModel)
        {
            var publicationToUpdate = _context.Publications.Single(x => x.Id == viewModel.Publication.Id);

            publicationToUpdate.CategoryId = viewModel.Publication.CategoryId;
            publicationToUpdate.Content = viewModel.Publication.Content;
            publicationToUpdate.IsExecuted = viewModel.Publication.IsExecuted;
            publicationToUpdate.PublicationDate = DateTime.Now;
            publicationToUpdate.Title = viewModel.Publication.Title;
            publicationToUpdate.Price = viewModel.Publication.Price;

            FileModelRepository fileModel = new FileModelRepository();
            Action<IEnumerable<IFormFile>, int> delegateAddImages =  fileModel.AddImages;
            delegateAddImages(viewModel.FileModels,viewModel.Publication.Id);
           
        }

        public void Delete(int id, string userId)
        {
            var publicationToDelete = _context.Publications.Single(x => x.Id == id && x.UserId == userId);

            _context.Publications.Remove(publicationToDelete);
        }

        public void Publish(int id, string userId)
        {
           var publication=_context.Publications.Single(x => x.Id == id && x.UserId==userId);
            publication.IsExecuted = true;
        }

        public void Remove(int id, string userId)
        {
            var publication = _context.Publications.Single(x => x.Id == id && x.UserId == userId);
            publication.IsExecuted = false;
        }

        

    }
}
