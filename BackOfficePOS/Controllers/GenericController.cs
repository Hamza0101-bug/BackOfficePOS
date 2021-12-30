using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using Core.Entities;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification;
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
        private readonly IMapper _mapper;
        public GenericController(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Brand> brandRepo,
            IGenericRepository<Category> categoryRepo, 
            IMapper mapper)
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }


        [HttpGet("Product")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductWithBrandCategorySpecification();
            var products = await _productRepo.ListAsync(spec);
            return Ok( _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetEntitywithspec(int id)
        {
            var spec = new ProductWithBrandCategorySpecification(id);
            var product = await _productRepo.GetEntitywithspec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product, ProductDto>(product));
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
