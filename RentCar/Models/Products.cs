using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Products
    {
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }

        [Required]
        public string Matricule { get; set; }
        [Required]
        public int annee { get; set; }

        [Required]
        public int Kilometrage { get; set; }

        [Required]
        public decimal Price { get; set; }


        public string Image { get; set; }

        [Required]
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Product Type")]
        [Required]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]

        public virtual ProductTypes ProductTypes { get; set; }
        [Required]
        [Display(Name = "Sepcial Tag")]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public  SpecialTag SpecialTag { get; set; }

        [Display(Name = "Proprietaire")]
        [Required]
        public int ProprietaireId { get; set; }
        [ForeignKey("ProprietaireId")]

        public virtual Proprietaire Proprietaire { get; set; }



    }
}
