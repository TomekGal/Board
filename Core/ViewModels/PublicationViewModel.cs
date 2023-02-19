using Board.Core.Models;
using Board.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.ViewModels
{
    public class PublicationViewModel
    {
        public string Heading { get; set; }
        public Publication Publication { get; set; }

        //[Required(ErrorMessage = "Pole Kategoria jest wymagane")]
        //[Display(Name = "Kategoria")]
        public IEnumerable<Category> Categories { get; set; }

        public List<SelectListItem> CategoriesList { get; set; }

        public string Name { get; set; }

        //[Required(ErrorMessage = "Proszę wybrać plik")]
        //[DataType(DataType.Upload)]
        //public FileModel FileModel { get; set; }
        public int publicationId { get; set; }

        public List<string> FilesList { get; set; }

        [Required(ErrorMessage = "Proszę wybrać plik")]
        [DataType(DataType.Upload)]
        public List<IFormFile> FileModels { get; set; }
       

    }
}
