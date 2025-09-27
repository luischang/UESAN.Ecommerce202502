using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
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
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CORE.Core.Entities.Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var newCategoryId = await _categoryRepository.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), 
                new { id = newCategoryId }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteCategory(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id
            , [FromBody] CORE.Core.Entities.Category category)
        {
            if (category == null || category.Id != id)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryRepository.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryRepository.UpdateCategory(category);
            return NoContent();
        }
    }
}
