using Microsoft.EntityFrameworkCore;
using OnlineShoePortal_DynamicWebsite_.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_DynamicWebsite_.Data
{
    public class ToyRepository : IToyRepository
    {
        private readonly ToyContext _ctx;

        public ToyRepository(ToyContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEntity(OrderViewModel model)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            return _ctx.Orders
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Product)
                       .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                    .OrderBy(p => p.Title)
                    .ToList();
        }

        public OrderViewModel GetOrderById(int id)
        {
            return _ctx.Orders
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Product)
                       .Where(o => o.Id == id)
                       .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsbyCategory(string Category)
        {
            return _ctx.Products
                .Where(p => p.Category == Category)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
