using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// [Required], [StringLength(255)]
using System.ComponentModel.DataAnnotations;

namespace vroom.Models
{
    public class Make
    {
        public string User_Id { get; set; }

        public int Id { get; set; }

        //Source: https://stackoverflow.com/questions/35384987/what-is-a-simple-explanation-for-displayfor-and-displaynamefor-in-asp-net
        [Display(Name = "Current name")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        //public ICollection<Model> Models { get; set; }
    }
}
