using Board.Core;
using Board.Core.Models.Domains;
using Board.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Board.Persistence.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private IApplicationDbContext _context;

        public PublicationRepository(IApplicationDbContext context)
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

        public void Update(Publication publication)
        {
            var publicationToUpdate = _context.Publications.Single(x => x.Id == publication.Id);

            publicationToUpdate.CategoryId = publication.CategoryId;
            publicationToUpdate.Content = publication.Content;
            publicationToUpdate.IsExecuted = publication.IsExecuted;
            publicationToUpdate.PublicationDate = publication.PublicationDate;
            publicationToUpdate.Title = publication.Title;
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

       

       
    }
}
