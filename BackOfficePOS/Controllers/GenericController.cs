using Core.Entities;
using Core.Interfaces.GenericInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IGenericRepository<Product>   _productRepo;
        private readonly IGenericRepository<Brand>     _brandRepo;
        private readonly IGenericRepository<Category> _categoryRepo;

        public GenericController(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Brand> brandRepo,
            IGenericRepository<Category> categoryRepo )
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet("Product")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _productRepo.ListAllAsync());
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<List<Brand>>> GetProductBrands()
        {
            return Ok(await _brandRepo.ListAllAsync());
        }
        [HttpGet("Category")]
        public async Task<ActionResult<List<Category>>> GetProductCategories()
        {
            return Ok(await _categoryRepo.ListAllAsync());
        }
    }
}
