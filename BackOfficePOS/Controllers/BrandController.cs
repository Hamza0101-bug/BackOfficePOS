using BackOfficePOS.Errors;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        private readonly IGenericRepository<Brand> _brandRepo;
        public BrandController(IGenericRepository<Brand> brandRepo)
        {
            _brandRepo = brandRepo;
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<List<Brand>>> GetProductBrands()
        {
            return Ok(await _brandRepo.ListAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetProductBrandbyID(int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand == null) return NotFound(new ApiResponse(404));

            return Ok(brand);

        }

    }
}
