using System;

namespace Product_Catalog.DataObjects
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductHistory
    {
        public int ProductHistoryId { get; set; }
        public int ProductId { get; set; }
        public double NewPrice { get; set; }
        public string NewName { get; set; }
        public DateTime UpdateTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ProductHistory product = obj as ProductHistory;
            if (product == null) return false;
            return product.ProductId == this.ProductId && this.NewPrice == product.NewPrice;
        }
    }
}
