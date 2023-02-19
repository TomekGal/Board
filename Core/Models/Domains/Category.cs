using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Publications = new Collection<Publication>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public string Name { get; set; }

        //public string UserId { get; set; }
        //public bool IsChecked { get; set; }

        public ICollection<Publication> Publications { get; set; }

        //public ApplicationUser User { get; set; }
    }
}
