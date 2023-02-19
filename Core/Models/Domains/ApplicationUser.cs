using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Board.Core.Models.Domains
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Publications = new Collection<Publication>();
            Categories = new Collection<Category>();

        }
        public ICollection<Publication> Publications { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
