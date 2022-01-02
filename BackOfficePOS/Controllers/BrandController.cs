using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Entities;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification.EnitiySpecificationImplementation.SpectForData;
using Core.Interfaces.Specification.EntitySpecifications;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        private readonly IGenericRepository<Brand> _brandRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandController(
            IGenericRepository<Brand> brandRepo,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Brands")]
        public async Task<ActionResult<Pagination<Brand>>> GetProductBrands([FromQuery] CommonSpecParams commonSpecParams)
        {
            var spec = new BrandSpecification(commonSpecParams); // this spec use for adding Craiteria or adding includs
            var brands = await _brandRepo.ListAsync(spec);

            var countspec = new BrandCountSpec(commonSpecParams); // this spec use to get the count of records and current page siza and index
            var totalItem = await _brandRepo.CountAsync(countspec);

            var data = _mapper.Map<IReadOnlyList<Brand>, IReadOnlyList<BrandDto>>(brands); // Data with mapping
            return Ok(new Pagination<BrandDto>(commonSpecParams.PageIndex, commonSpecParams.PageSize, totalItem, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetProductCategorybyID(int id)
        {
            var spec = new BrandSpecification(id);
            var category = await _brandRepo.GetEntityAsync(spec);
            if (category == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Brand, BrandDto>(category));

        }

        [HttpPost("AddBrands")]
        public async Task<ActionResult<bool>> AddBrands([FromForm] SaveBrandDTO SaveBrandDTO)
        {
            if (SaveBrandDTO.ImageFile.Length > 0)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath + "\\Images\\BrandImages");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var stream = new FileStream(Path.Combine(path, SaveBrandDTO.ImageFile.FileName), FileMode.Create))
                {
                    SaveBrandDTO.ImageFile.CopyTo(stream);
                    stream.Flush();
                }
            }
            SaveBrandDTO.BrandImage = SaveBrandDTO.ImageFile.FileName;
            var brand = _mapper.Map<SaveBrandDTO, Brand>(SaveBrandDTO);
            var added = await _brandRepo.InsertUpdateAsync(brand);
            return Ok(added);
        }

    }
}
