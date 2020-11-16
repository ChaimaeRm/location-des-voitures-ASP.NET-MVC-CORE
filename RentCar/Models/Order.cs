using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Order
    {
        public Order()
        {
            orderDetails = new List<OrderDetails>();    
        }

        public int id { set; get; }
        [Required]
        [Display(Name="Order No")]
        public string OrderNo { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        [Display(Name="Phone No")]
        public string PhoneNo { set; get; }

        [Required]
        [EmailAddress]
        
        public string Email { set; get; }
        [Required]
        public string Address { set; get; }
        public DateTime OrderDate { set; get; }

        public virtual List<OrderDetails> orderDetails { set; get; }
    }
}
