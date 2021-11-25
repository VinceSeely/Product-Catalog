using Microsoft.EntityFrameworkCore;
using Product_Catalog.DataObjects;
using System.Collections.Generic;

namespace Product_Catalog.Services
{
    public interface IProductCatalogContext
    {
        int SaveChanges();
        void UpdateProduct(Product product);
        void AddProduct(Product product);
        void AddProductHistory(ProductHistory productHistory);

        DbSet<Product> Product { get; set; }
        DbSet<ProductHistory> ProductHistory { get; set; }

        IEnumerable<ProductHistory> GetHistory(int product);
    }
}