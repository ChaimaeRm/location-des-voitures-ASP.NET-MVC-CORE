using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class OrderDetails
    {
        public int id {set;get;}

        [Display(Name="Order")]
        public int OrderId {set ; get;}

        [Display(Name="Product")]
        public int ProductId {set ; get;}

        [ForeignKey("OrderId")]
        public Order order { set; get; }

        [ForeignKey("OrderId")]
        public Products product { set; get; }
    }
}
