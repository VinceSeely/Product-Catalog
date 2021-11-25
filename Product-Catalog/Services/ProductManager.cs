using Product_Catalog.DataObjects;
using System.Collections.Generic;

namespace Product_Catalog.Services
{
    public class ProductManager : IProductManager
    {
        private readonly IProductCatalogContext productCatalogContext;

        public ProductManager(IProductCatalogContext productCatalogContext)
        {
            this.productCatalogContext = productCatalogContext;
        }

        public bool UpdateProduct(Product product)
        {
            var result = true;
            if (product == null)
            {
                result = false;
            }
            else
            {
                productCatalogContext.UpdateProduct(product);
                var productHistory = new ProductHistory()
                {
                    NewPrice = product.Price,
                    ProductId = product.Id
                };
                productCatalogContext.AddProductHistory(productHistory);
                productCatalogContext.SaveChanges();
            }
            return result;
        }

        public bool AddProduct(Product product)
        {
            var result = true;
            if (product == null)
            {
                result = false;
            }
            else
            {
                productCatalogContext.AddProduct(product);
                productCatalogContext.SaveChanges();
                var productHistory = new ProductHistory()
                {
                    NewPrice = product.Price,
                    ProductId = product.Id
                };
                productCatalogContext.AddProductHistory(productHistory);
                productCatalogContext.SaveChanges();
            }
            return result;
        }

        public IEnumerable<ProductHistory> GetHistory(int product)
        {
            return productCatalogContext.GetHistory(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productCatalogContext.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return productCatalogContext.GetProduct(id);
        }
    }
}
