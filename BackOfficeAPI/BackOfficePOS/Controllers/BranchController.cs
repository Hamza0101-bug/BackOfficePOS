using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Entities;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification.EnitiySpecificationImplementation.SpectForData;
using Core.Interfaces.Specification.EntitySpecifications;
using Core.Interfaces.Specification.SpecificationImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IGenericRepository<Branch> _branchRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BranchController(IGenericRepository<Branch> branchRepo , IMapper mapper , IWebHostEnvironment webHostEnvironment)
        {
            _branchRepo = branchRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost("Branchs")]
        public async Task<ActionResult<Pagination<Branch>>> GetBranchs([FromQuery] CommonSpecParams commonSpecParams)
        {
            var spec = new BranchSpecification(commonSpecParams); // this spec use for adding Craiteria or adding includs
            var brands = await _branchRepo.ListAsync(spec);

            var countspec = new BranchCountSpec(commonSpecParams); // this spec use to get the count of records and current page siza and index
            var totalItem = await _branchRepo.CountAsync(countspec);

            var data = _mapper.Map<IReadOnlyList<Branch>, IReadOnlyList<BranchDto>>(brands); // Data with mapping
            return Ok(new Pagination<BranchDto>(commonSpecParams.PageIndex, commonSpecParams.PageSize, totalItem, data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetProductCategorybyID(int id)
        {
            var spec = new BranchSpecification(id);
            var branch = await _branchRepo.GetEntityAsync(spec);
            if (branch == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Branch, Branch>(branch));

        }

        [HttpPost("AddBranch")]
        public async Task<ActionResult<bool>> AddBrands([FromForm] SaveBranchDTO saveBranchDTO)
        {
            //if (SaveBrandDTO.ImageFile.Len gth > 0)
            //{
            //    string path = Path.Combine(_webHostEnvironment.WebRootPath + "\\Images\\BrandImages");
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }
            //    using (var stream = new FileStream(Path.Combine(path, SaveBrandDTO.ImageFile.FileName), FileMode.Create))
            //    {
            //        SaveBrandDTO.ImageFile.CopyTo(stream);
            //        stream.Flush();
            //    }
            //}
            //SaveBrandDTO.BrandImage = SaveBrandDTO.ImageFile.FileName;
            var branch = _mapper.Map<SaveBranchDTO, Branch>(saveBranchDTO);
            var added = await _branchRepo.InsertUpdateAsync(branch);
            return Ok(added);
        }
    }
}
