using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductTypes>ProductTypes { get; set; }
        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SpecialTag> SpecialTags { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<ApplicationUser> applicationUsers{ get; set; }
    }
}
