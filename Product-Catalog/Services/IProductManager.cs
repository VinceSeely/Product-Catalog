using Product_Catalog.DataObjects;
using System.Collections.Generic;

namespace Product_Catalog.Services
{
    public interface IProductManager
    {
        bool UpdateProduct(Product product);
        bool AddProduct(Product product);
        IEnumerable<ProductHistory> GetHistory(int product);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
