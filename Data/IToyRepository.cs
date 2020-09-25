using OnlineShoePortal_DynamicWebsite_.Data.Entities;
using System;
using System.Collections.Generic;

namespace OnlineShoePortal_DynamicWebsite_.Data
{
    public interface IToyRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsbyCategory(string Category);
        IEnumerable<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        bool SaveAll();
        void AddEntity(Object model);
    }
}