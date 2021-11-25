using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product_Catalog.DataObjects;
using Product_Catalog.Services;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/<ProductController>
        [HttpGet("history/{id}")]
        public IEnumerable<ProductHistory> GetHistory(int id)
        {
            return this._productManager.GetHistory(id);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
    }
}
