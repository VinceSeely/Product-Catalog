using NUnit.Framework;
using Moq;
using Product_Catalog.DataObjects;
using Product_Catalog.Services;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Services
{

    [TestFixture]
    public abstract class ProductManagerTests : BaseUnitTest
    {
        protected ProductManager sut;
        protected Mock<IProductCatalogContext> mockProductCatalog = new Mock<IProductCatalogContext>();

        protected override void Setup()
        {
            sut = new ProductManager(mockProductCatalog.Object);
        }
        protected override void Mock()
        {
        }
    }

    public class when_updating_a_products_price : ProductManagerTests
    {
        private bool result;
        private Product product;
        private ProductHistory productHistory;

        protected override void Setup()
        {
            base.Setup();
            product = new Product()
            {
                Id = 1,
                Price = 3.4
            };
            productHistory = new ProductHistory()
            {
                ProductId = 1,
                NewPrice = 3.4
            };
        }


        protected override void Run()
        {
            result = sut.UpdateProduct(product);
        }

        [Test]
        public void then_no_change_happens_and_the_caller_is_informed()
        {
            Assert.IsTrue(result);
        }

        [Test]
        public void then_there_should_be_an_addition_to_the_database()
        {
            mockProductCatalog.Verify(x => x.UpdateProduct(product));
        }

        [Test]
        public void then_the_save_of_the_database_should_be_called_once()
        {
            mockProductCatalog.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void then_a_update_to_the_history_of_the_product_should_be_add()
        {
            mockProductCatalog.Verify(x => x.AddProductHistory(productHistory));
        }
    }

    public class when_adding_a_new_product_to_the_database_but_the_product_is_null : ProductManagerTests
    {
        private bool result;

        protected override void Run()
        {
            result = sut.AddProduct(null);
        }

        [Test]
        public void then_the_result_should_be_false()
        {
            Assert.IsFalse(result);
        }

        [Test]
        public void then_it_should_not_call_the_update_product_method()
        {
            mockProductCatalog.Verify(x => x.AddProduct(null), Times.Never);
        }

        [Test]
        public void then_it_should_not_call_the_save_data_method()
        {
            mockProductCatalog.Verify(x => x.SaveChanges(), Times.Never);
        }

    }

    public class when_adding_a_new_product_to_the_database : ProductManagerTests
    {
        private bool result;
        private Product product;
        private ProductHistory productHistory;

        protected override void Setup()
        {
            base.Setup();
            product = new Product()
            {
                Id = 1,
                Price = 3.4
            };
            productHistory = new ProductHistory()
            {
                ProductId = 1,
                NewPrice = 3.4
            };
        }

        protected override void Run()
        {
            result = sut.AddProduct(product);
        }

        [Test]
        public void then_the_result_should_be_false()
        {
            Assert.IsTrue(result);
        }

        [Test]
        public void then_the_add_product_method_for_the_db_context_should_be_called()
        {
            mockProductCatalog.Verify(x => x.AddProduct(product));
        }

        [Test]
        public void then_a_update_to_the_history_of_the_product_should_be_add()
        {
            mockProductCatalog.Verify(x => x.AddProductHistory(productHistory));
        }
    }

    public class when_updating_a_products_price_but_the_product_is_null : ProductManagerTests
    {
        private bool result;

        protected override void Run()
        {
            result = sut.UpdateProduct(null);
        }


        [Test]
        public void then_it_should_not_call_the_update_product_method()
        {
            mockProductCatalog.Verify(x => x.AddProduct(null), Times.Never);
        }

        [Test]
        public void then_it_should_not_call_the_save_data_method()
        {
            mockProductCatalog.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Test]
        public void then_no_change_happens_and_the_caller_is_informed()
        {
            Assert.IsFalse(result);
        }
    }

    public class when_getting_the_results_of_a_product_list : ProductManagerTests
    {
        private List<ProductHistory> result;
        private Product product;
        private ProductHistory productHistory;

        protected override void Setup()
        {
            base.Setup();
            product = new Product()
            {
                Id = 1,
                Price = 3.4
            };
            productHistory = new ProductHistory()
            {
                ProductId = 1,
                NewPrice = 3.4
            };
        }

        protected override void Mock()
        {
            base.Mock();
            mockProductCatalog.Setup(x => x.GetHistory(1)).Returns(new List<ProductHistory>() { new ProductHistory { ProductId = 1, NewPrice = 3.4 } });
        }

        protected override void Run()
        {
            result = sut.GetHistory(1).ToList();
        }

        [Test]
        public void then_no_change_happens_and_the_caller_is_informed()
        {
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void then_the_get_history_method_on_the_context_is_called()
        {
            mockProductCatalog.Verify(x => x.GetHistory(1));
        }
    }

    public class when_get_requesting_a_product : ProductManagerTests
    {
        private Product result;
        private int id;

        protected override void Setup()
        {
            base.Setup();
            id = 1;
        }

        protected override void Run()
        {
            result = sut.GetProduct(1);
        }

        [Test]
        public void then_the_get_product_method_should_be_called_on_the_db_context()
        {
            mockProductCatalog.Verify(x => x.GetProduct(id));
        }
    }

    public class when_get_requesting_a_product_list : ProductManagerTests
    {
        private IEnumerable<Product> result;
        private int id;

        protected override void Setup()
        {
            base.Setup();
            id = 1;
        }

        protected override void Run()
        {
            result = sut.GetProducts();
        }

        [Test]
        public void then_the_get_product_method_should_be_called_on_the_db_context()
        {
            mockProductCatalog.Verify(x => x.GetProducts());
        }
    }
}
