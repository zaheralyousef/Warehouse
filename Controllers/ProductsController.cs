using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Data;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductService _productService;
        
        public ProductsController(IProductService prodcutService)
        {            
            _productService = prodcutService;            
        }
        // Create/Add a new product
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody]Product product)
        {
            try
            {
                if(product != null)
                {
                    _productService.AddProduct(product);
                    return Ok();
                }
                return BadRequest("Product was not added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // Get all products
        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var allProducts = _productService.GetAllProducts();
            return Ok(allProducts);
        }

        // Update an exesting product
        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody]Product product)
        {
            _productService.UpdateProduct(id, product);
            return Ok(product);
        }

        // Delete a product
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        // Sell a product
        [HttpDelete("SellProduct/{id}")]
        public IActionResult SellProduct(int id)
        {
            _productService.SellProduct(id);
            return Ok();
        }

        // Get a single product
        [HttpGet("SingleProduct/{id}")]
        public IActionResult SingleProduct(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
    }
}
