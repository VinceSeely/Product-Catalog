using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product_Catalog.DataObjects;
using Product_Catalog.Services;
using System;
using System.Collections.Generic;

namespace Product_Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductManager _productManager;

        public ProductController(ILogger<ProductController> logger, IProductManager productManager)
        {
            _logger = logger;
            this._productManager = productManager;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return this._productManager.GetProducts();
        }


        // GET: api/<ProductController>
        [HttpGet("history/{id}")]
        public IEnumerable<ProductHistory> GetHistory(int id)
        {
            return this._productManager.GetHistory(id);
        }

        // POST api/<ProductController>/update
        [HttpPost("update")]
        public void UpdateProduct([FromBody] Product product)
        {
            this._productManager.UpdateProduct(product);
        }

        // PUT api/<ProductController>/add
        [HttpPut("add")]
        public bool AddProduct([FromBody] Product product)
        {
            return this._productManager.AddProduct(product);
        }


        // GET: api/<ProductController>/9
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return this._productManager.GetProduct(id);
        }
    }
}
