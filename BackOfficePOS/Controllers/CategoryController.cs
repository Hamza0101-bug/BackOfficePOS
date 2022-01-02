using AutoMapper;
using BackOfficePOS.DTOs;
using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.Specification.EnitiySpecificationImplementation.SpectForData;
using Core.Interfaces.Specification.EntitySpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IMapper _mapper;
        public CategoryController(IGenericRepository<Category> categoryRepo , IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Category")]
        public async Task<ActionResult<Pagination<Category>>> GetProductCategories(CategorySpecParams categorySpecParams)
        {
            var spec = new CategorySpecification(categorySpecParams);
            var category = await _categoryRepo.ListAsync(spec);

            var Countspec = new CategoryCountSpec(categorySpecParams);
            var totalItem =  await _categoryRepo.CountAsync(Countspec);

            var data = _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDto>>(category); // Data with mapping
            return Ok(new Pagination<CategoryDto>(categorySpecParams.PageIndex, categorySpecParams.PageSize, totalItem, data));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetProductCategorybyID(int id)
        {
            var spec = new CategorySpecification(id);
            var category = await _categoryRepo.GetEntityAsync(spec);
            if (category == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Category, CategoryDto>(category));

        }

        [HttpPost("InsertUpdateAsync")]
        public async Task<ActionResult<bool>> InsertUpdateAsync([FromForm] SaveCategoryDTO savecategoryDto)
        {
            if (savecategoryDto.ImageFile.Length > 0)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath + "\\Images\\CategoryImages");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var stream = new FileStream(Path.Combine(path, savecategoryDto.ImageFile.FileName), FileMode.Create))
                {
                    savecategoryDto.ImageFile.CopyTo(stream);
                    stream.Flush();
                }
            }
            savecategoryDto.CategoryImage = savecategoryDto.ImageFile.FileName;
            var category = _mapper.Map<CategoryDto, Category>(savecategoryDto);
            var added = await _categoryRepo.InsertUpdateAsync(category);
            return Ok(added);
        }
    }
}
