using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Nom{ get; set; }

        [Required]
        public string Prenom{ get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telephone")]
        public int tel { get; set; }

        [Required]
        public string CIN { get; set; }

    }
}
