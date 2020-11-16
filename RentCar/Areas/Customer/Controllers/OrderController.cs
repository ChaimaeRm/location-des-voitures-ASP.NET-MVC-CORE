using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Data;
using RentCar.Models;
using RentCar.Utility;

namespace RentCar.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET ACTION METHOD
        public IActionResult Checkout()
        {
            return View();
        }

        //POST ACTION METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(Order anOrder)
        {
            List<Products> products=HttpContext.Session.Get<List<Products>>("products");
            if(products!=null)
            {
                foreach(var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
                    anOrder.orderDetails.Add(orderDetails);
                }
            }
            anOrder.OrderNo = getOrderNo();
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products",new List<Products>());
            return View();  
        }

        public string getOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count()+1;
            return rowCount.ToString("000");
        }

    }
}