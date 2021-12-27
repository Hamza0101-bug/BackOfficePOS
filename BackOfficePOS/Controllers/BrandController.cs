using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brand>>> GetProductBrands()
        {
            var Brands = await _brandRepository.GetProductBrandsAsync();
            return Ok(Brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetProductBrandbyID(int id)
        {
            var brand = await _brandRepository.GetProductBrandbyIDAsync(id);
            return Ok(brand);

        }

    }
}
