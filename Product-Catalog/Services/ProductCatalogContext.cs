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
            Console.WriteLine(product.Name);
            Product.Add(product);
            Console.WriteLine(product.Id);
        }

        public void AddProductHistory(ProductHistory productHistory)
        {

            Console.WriteLine(productHistory.ProductId);
            ProductHistory.Add(productHistory);
        }

        public IEnumerable<ProductHistory> GetHistory(int product)
        {
            return ProductHistory.Where(x => x.ProductId == product);
        }

        public void UpdateProduct(Product product)
        {
            Console.WriteLine(product.Name);
            var productBeingUpdated = Product.Find(product.Id);
            productBeingUpdated.Name = product.Name;
            productBeingUpdated.Price = product.Price;
        }
    }
}
