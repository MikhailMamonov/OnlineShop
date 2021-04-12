using Microsoft.AspNetCore.Mvc;

using OnlieShop.Domain.Models.Entities;

using OnlineShop.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        IProductsService _productsService;
        public ProductsController(IProductsService productsService) 
        {
            _productsService = productsService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] Product product)
        {
            var result = _productsService.AddProduct(product);
            return Ok(result);
        }
        [HttpPost("Category")]
        public ActionResult AddCategory([FromForm] Category category)
        {
            _productsService.AddCategory(category);
            return Ok(category);
        }

        [HttpGet]
        public IActionResult Products() {
            var products = _productsService.GetProducts();
            return Ok(products);
        }

        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            var categories = _productsService.GetCategories();
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            _productsService.UpdateProduct(id, product);
            return Ok(product);
        }

        [HttpPut("Category/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category) 
        {
            _productsService.UpdateCategory(id, category);
            return Ok(category);
        }

        [HttpDelete("Category/{id}")]
        public IActionResult DeleteCategory(int id) 
        {
            if (!_productsService.GetCategories().Any(category => category.Id == id)) 
            {
                return BadRequest("Category id not found");
            }
            _productsService.DeleteCategory(id);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (!_productsService.GetProducts().Any(product => product.Id == id))
            {
                return BadRequest("Product id not found");
            }
            _productsService.DeleteProduct(id);
            return Ok(id); 
        }
    }
}
