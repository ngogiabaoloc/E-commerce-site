using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// [Required], [StringLength(255)]
using System.ComponentModel.DataAnnotations;

namespace vroom.Models
{
    public class Book
    {
       
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }

        public string ImagePath { get; set; }

        public string User_Id { get; set; }

    }
}
