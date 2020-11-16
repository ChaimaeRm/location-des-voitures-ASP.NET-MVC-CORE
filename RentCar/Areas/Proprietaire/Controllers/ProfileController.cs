using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    [Area("Proprietaire")]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _db;
        public ProfileController(ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var pro = _db.Proprietaires.Find(id);
            return View(pro);
        }

        public IActionResult listVoiture(int id)
        {
            ViewBag.nameProp = _db.Proprietaires.Find(id).Name;
            var prod = _db.Products.Include(c => c.SpecialTag).Include(c => c.ProductTypes).Include(c => c.Proprietaire).Where(c=>c.ProprietaireId==id).ToList();
            return View(prod);
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var proprietaire = _db.Proprietaires.Find(id);
            if (proprietaire == null) 
            {
                return NotFound();
            }
            return View(proprietaire);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Proprietaire proprietaire) 
        {
            if (ModelState.IsValid)
            {
                //_db.Proprietaires.ToList();
                _db.Proprietaires.Update(proprietaire);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new {id=proprietaire.Id });
            }
            return View();
        }

    }
}