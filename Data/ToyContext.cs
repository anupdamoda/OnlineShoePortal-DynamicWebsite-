using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoePortal_DynamicWebsite_.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_DynamicWebsite_.Data
{
    public class ToyContext : IdentityDbContext<StoreUser>
    {

        public ToyContext(DbContextOptions<ToyContext> options): base (options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderViewModel> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderViewModel>()
                .HasData(new OrderViewModel()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
        }
    }
}
