using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Display(Name = "Nom d'agence")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Telephone")]
        public string tel { get; set; }

        [Required]
        [Display(Name = "Adresse d'agence")]
        public string adresse { get; set; }

        [Required]
        [Display(Name = "CIN")]
        public string cin { get; set; }
    }
}
