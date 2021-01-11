using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace vroom.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Office Phone")]
        public string PhoneNumber2 { get; set; }

        // not reflected in database table
        [NotMapped]
        public bool IsAdmin { get; set; }
    }
}
