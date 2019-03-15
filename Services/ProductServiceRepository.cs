using Core_webApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_webApp.Services
{
    public class ProductServiceRepository : IRepositoryService<Product, int>
    {
        SaxoDbAppContext ctx;

        public ProductServiceRepository(SaxoDbAppContext ctx)
        {
            this.ctx = ctx;
        }

        public Product Create(Product entity)
        {
            ctx.Products.Add(entity); // Insert
            ctx.SaveChanges(); // Transaction Method, Auto-Update Insert;select
            return entity;
        }

        public bool Delete(int id)
        {
            var isDeleted = false;
            var prd = ctx.Products.Find(id);
            if (prd != null)
            {
                ctx.Products.Remove(prd);
                ctx.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;

        }

        public IEnumerable<Product> Get()
        {
            return ctx.Products;
        }

        public Product Get(int id)
        {
            return ctx.Products.Find(id);
        }

        public bool Update(int id, Product entity)
        {
            var isUpdated = false;
            var prd = ctx.Products.Find(id);
            if (prd != null)
            {
                prd.ProductName = entity.ProductName;
                prd.BasePrice = entity.BasePrice;
                prd.CategoryName = entity.CategoryName;
                prd.Manufacturer = entity.Manufacturer;
                ctx.SaveChanges();
                isUpdated = true;
            }
            return isUpdated;
        }
    }
}
