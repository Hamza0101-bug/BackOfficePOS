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
    public class CategoryController : BaseApiController
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        public CategoryController(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet("Category")]
        public async Task<ActionResult<List<Category>>> GetProductCategories()
        {
            return Ok(await _categoryRepo.ListAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetProductCategorybyID(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null) return NotFound(new ApiResponse(404));

            return Ok(category);

        }
    }
}
