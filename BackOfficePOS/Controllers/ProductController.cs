using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Entities;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification;
using Core.Interfaces.Specification.EntitySpecifications;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(
            IGenericRepository<Product> productRepo,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Product")] // get all prducts
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecParams proprams)
        {
            var spec = new ProductWithBrandCategorySpecification(proprams); // this spec use for adding Craiteria or adding includs
            var countspec = new ProductCountSpec(proprams); // this spec use to get the count of records and current page siza and index
            var totalItem =   await _productRepo.CountAsync(countspec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(proprams.PageIndex, proprams.PageSize,totalItem,data));
        }

        [HttpGet("{id}")] // get product by id
        public async Task<ActionResult<ProductDto>> GetEntitywithspec(int id)
        {
            var spec = new ProductWithBrandCategorySpecification(id);
            var product = await _productRepo.GetEntityAsync(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product, ProductDto>(product));
        }


        [HttpPost("InsertUpdateAsync")] // save product
        public async Task<ActionResult<bool>> InsertUpdateAsync([FromForm]productSaveDto productsaveDto)
        {
            if (productsaveDto.ProductImage.Length>0)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath + "\\Images\\ProductImages");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var stream = new FileStream(Path.Combine(path, productsaveDto.ProductImage.FileName), FileMode.Create))
                {
                    productsaveDto.ProductImage.CopyTo(stream);
                    stream.Flush();
                }
            }
            productsaveDto.ImageName = productsaveDto.ProductImage.FileName;
            var product = _mapper.Map<productSaveDto, Product>(productsaveDto);
            var added =   await _productRepo.InsertUpdateAsync(product);
            return Ok(added);
        }
    }
}
