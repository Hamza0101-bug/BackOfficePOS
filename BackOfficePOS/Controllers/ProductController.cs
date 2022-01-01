using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification;
using Core.Interfaces.Specification.EnitiySpecificationImplementation;
using Core.Interfaces.Specification.EntitySpecifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("Product")] // get all prducts
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecParams proprams)
        {
            var spec = new ProductWithBrandCategorySpecification(proprams); // this spec use for adding Craiteria or adding includs
            var countspec = new ProductWithFilterCountSpec(proprams); // this spec use to get the count of records and current page siza and index
            var totalItem =   await _productRepo.CountAsync(countspec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(proprams.PageIndex, proprams.PageSize,totalItem,data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetEntitywithspec(int id)
        {
            var spec = new ProductWithBrandCategorySpecification(id);
            var product = await _productRepo.GetEntitywithspec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product, ProductDto>(product));
        }
        [HttpPost("SaveProduct")]

        public async  Task<ActionResult<Product>> SaveProduct(productSaveDto producttosave)
        {
            var product = _mapper.Map<productSaveDto, Product>(producttosave);
            
            var p =  await _productRepo.SaveAsync(product);
            return Ok(p);
     
        }
    }
}
