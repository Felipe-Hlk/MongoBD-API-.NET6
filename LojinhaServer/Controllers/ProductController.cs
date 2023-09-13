using LojinhaServer.Collections;
using LojinhaServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojinhaServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController (IProductRepository repo)
        {
            _repo - repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _repo.GetAllAsync();
            return Ok(product);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
                return Ok(product);
        }


        
    }
}