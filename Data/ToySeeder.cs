using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using OnlineShoePortal_DynamicWebsite_.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_DynamicWebsite_.Data
{
    public class ToySeeder
    {
        private readonly ToyContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private UserManager<StoreUser> _userManager;

        public ToySeeder(ToyContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();
            StoreUser user = await _userManager.FindByEmailAsync("anupd@gmail.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Anup",
                    LastName = "Damodaran",
                    Email = "anup.damoda@gmail.com",
                    UserName = "anup.damoda@gmail.com"
                };
            var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
            }
        
        

            if (!_ctx.Products.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(Products);
                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                    Product = Products.First(),
                    Quantity = 5,
                    UnitPrice = Products.First().Price
                        }
                    };
                }
                _ctx.SaveChanges();
            }
        }
    }
}
