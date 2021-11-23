﻿using System;
using System.Collections.Generic;
using System.Text;
using Product_Catalog.Controllers;
using UnitTests;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using Product_Catalog.DataObjects;
using Product_Catalog.Services;

namespace UnitTests.Controllers
{

    [TestFixture]
    public abstract class ProductControllerTests : BaseUnitTest
    {
        protected Mock<ILogger<ProductController>> mockLogger = new Mock<ILogger<ProductController>>();
        protected Mock<IProductManager> mockProductManager = new Mock<IProductManager>();

        protected ProductController temp;

        protected override void Setup()
        {
            temp = new ProductController(mockLogger.Object, mockProductManager.Object);
        }
        protected override void Mock()
        {
        }
    }

    [TestFixture]
    public class when_adding_a_product_to_the_catalog : ProductControllerTests
    {
        private int id;
        private string name;
        private double price;
        private Product product;

        protected override void Setup()
        {
            base.Setup();
            id = 1;
            name = "new product 1";
            price = 2.4;
            product = new Product() {
                Id = id,
                Name = name,
                Price = price
            };
        }

        protected override void Run()
        {
            temp.Post(product);
        }

        [Test]
        public void then_the_product_should_be_submitted_to_the_product_manager_to_be_added()
        {
            mockProductManager.Verify(x => x.CreateProduct(product));
        }
    }

    [TestFixture]
    public class when_updating_a_product_in_the_catalog : ProductControllerTests
    {

        protected override void Run()
        {
            throw new NotImplementedException();
        }
    }
}