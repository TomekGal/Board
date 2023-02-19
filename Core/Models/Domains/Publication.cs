using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Models.Domains
{
    public class Publication
    {
        public Publication()
        {
            //FileModels = new Collection<FileModel>();
        }
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Pole opis jest wymagane")]
        [Display(Name = "Opis")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Pole kategoria jest wymagane")]

        public int CategoryId { get; set; }

        [Display(Name = "Termin")]
        public DateTime? PublicationDate { get; set; }

        [Display(Name = "Zrealizowane")]
        public bool IsExecuted { get; set; }
        public string UserId { get; set; }
        //public int? FileModelId { get; set; }
        //public ICollection<FileModel> FileModels { get; set; }

        [Required(ErrorMessage = "Pole cena jest wymagane")]
        [Display(Name = "Cena")]
        public string Price { get; set; }

        [Display(Name = "Kategoria")]
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }

    }
}
