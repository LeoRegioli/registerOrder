using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Data.Interface;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICrudRepository<Product> _repo;

        public ProductController(ICrudRepository<Product> repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<IList<Product>>> GetAllProducts()
        {
            var listProduct = await _repo.GetAll();
            return (listProduct.Count > 0) ? Ok(listProduct) : NotFound("Product not found.");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest("Id is not valid");

            var product = await _repo.GetByIdAsync(id);
            return (product != null) ? Ok(product) : NotFound("Product not found.");
        }

        [HttpPost]
        public async Task<ActionResult<Product>> ProductPost(Product product)
        {
            if (product == null)
                return BadRequest("Error to create the product.");

            var resp = await _repo.Save(product);
            return (resp) ? Ok($"Product {product.Description} created successfully.") : BadRequest("Error to create the product.");
        }

        [HttpPut]
        public ActionResult<Product> ProductUpdate(Product product)
        {
            if (product == null)
                return BadRequest("Error to update the product.");

            var resp = _repo.Update(product);
            return (resp) ? Ok($"Product {product.Description} was updated with successfully.") : BadRequest("Error to update the product.");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Product> ProductDelete(int id)
        {
            if (id <= 0)
                return BadRequest("Error to delete the product.");

            var resp = _repo.Delete(id);
            return (resp) ? Ok("Product was deleted successfully.") : NotFound("Product not found.");
        }
    }
}