using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;
using RentCar.Utility;

namespace RentCar.Controllers
{   [Area("Customer")]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Products.Include(c=>c.ProductTypes).Include(c=>c.SpecialTag).ToList() );
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //GET ACTION METHOD
        public  ActionResult Detail(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c=>c.Id==id);
            if(product==null)
            {
                return NotFound();
            }

            return View(product);
        }

        //POST ACTION METHOD

        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetails(int? id)
        {
            List<Products> products = new List<Products>();

            if (id == null)
            {
                return NotFound();
            }
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<Products>>("products");
            if(products == null)
            { 
                products = new List<Products>();
            }
            products.Add(product);
            HttpContext.Session.Set("products",products);
                

            return View(product);
        }
        //GET METHOD ACTION
        [ActionName("Remove")]
        public IActionResult RemoveFromCart(int? id)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");

            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //¨POST METHOD ACTION
        [HttpPost]

        public IActionResult Remove(int? id)
        {

            List<Products> products = HttpContext.Session.Get<List<Products>>("products");

            if(products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if(product!=null)       
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products",products);
                } 
            }
            return RedirectToAction(nameof(Index));
        }

        //GET PRRODUCT CART ACTION METHOD
        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if(products==null)
            {
                products = new List<Products>();
            }
            return View(products);
        }
    }
}
