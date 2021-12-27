using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetProductCategories()
        {
            var Categories = await _categoryRepository.GetProductCategoryAsync();
            return Ok(Categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetProductCategorybyID(int id)
        {
            var category = await _categoryRepository.GetProductCategorybyIDAsync(id);
            return Ok(category);

        }
    }
}
