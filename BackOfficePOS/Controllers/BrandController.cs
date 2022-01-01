using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification;
using Core.Interfaces.Specification.EnitiySpecificationImplementation;
using Core.Interfaces.Specification.EnitiySpecificationImplementation.SpecForCount;
using Core.Interfaces.Specification.EnitiySpecificationImplementation.SpectForData;
using Core.Interfaces.Specification.EntitySpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        private readonly IGenericRepository<Brand> _brandRepo;
        private readonly IMapper _mapper;

        public BrandController(IGenericRepository<Brand> brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;


    }

    [HttpPost("Brands")]
        public async Task<ActionResult<Pagination<Brand>>> GetProductBrands([FromQuery]CommonSpecParams commonSpecParams)
        {
            var spec = new BrandSpecification(commonSpecParams); // this spec use for adding Craiteria or adding includs
            var countspec = new BrandWithFilterCountSpec(commonSpecParams); // this spec use to get the count of records and current page siza and index
            var totalItem = await _brandRepo.CountAsync(countspec);
            var brands = await _brandRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Brand>, IReadOnlyList<BrandDto>>(brands);
            return Ok(new Pagination<BrandDto>(commonSpecParams.PageIndex, commonSpecParams.PageSize, totalItem, data));
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
