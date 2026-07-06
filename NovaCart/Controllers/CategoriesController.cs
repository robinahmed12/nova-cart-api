

using Microsoft.AspNetCore.Mvc;
using NovaCart.DTOs;
using NovaCart.Model;
using NovaCart.Repositories;

namespace NovaCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //get all category
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var dtos = categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            });
            return Ok(dtos);
        }

        //get by id category
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var c = await _categoryRepository.GetByIdAsync(id);
            if (c == null) return NotFound();
            var dto = new CategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            };
            return Ok(dto);
        }

        //post category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            dto.CategoryId = category.CategoryId; // get generated ID
            return Ok(dto);
        }

        //update category 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO dto)
        {
            if (id != dto.CategoryId)
                return BadRequest("Id mismatch");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();
            existing.Name = dto.Name;
            existing.Description = dto.Description;
            _categoryRepository.Update(existing);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }

        // delete category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();
            _categoryRepository.Delete(existing);
            await _categoryRepository.SaveAsync();
            return NoContent();
        }
    }
}
