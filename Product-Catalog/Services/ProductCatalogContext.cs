using Microsoft.EntityFrameworkCore;
using Product_Catalog.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Catalog.Services
{
    public class ProductCatalogContext : DbContext, IProductCatalogContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductHistory> ProductHistory { get; set; }


        public void AddProduct(Product product)
        {
            Product.Add(product);
        }

        public void AddProductHistory(ProductHistory productHistory)
        {

            productHistory.UpdateTime = DateTime.UtcNow;
            ProductHistory.Add(productHistory);
        }

        public IEnumerable<ProductHistory> GetHistory(int product)
        {
            return ProductHistory.Where(x => x.ProductId == product);
        }

        public Product GetProduct(int id)
        {
            return Product.First(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return Product.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var productBeingUpdated = Product.Find(product.Id);
            productBeingUpdated.Name = product.Name;
            productBeingUpdated.Price = product.Price;
        }
    }
}
