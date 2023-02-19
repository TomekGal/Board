using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Models
{
    public class FilterPublications
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Tylko zrealizowane")]
        public bool IsExecuted { get; set; }
    }
}
