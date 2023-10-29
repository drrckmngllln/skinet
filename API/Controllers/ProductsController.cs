using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly StoreContext _context;
        private readonly IProductRepository _repo;
        
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            return Ok(await _repo.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}