using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlhadiLibrary.Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto, CancellationToken ct)
        {
            var id = await categoryService.CreateAsync(dto, ct);
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto, CancellationToken ct)
        {
            await categoryService.UpdateAsync(dto, ct);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await categoryService.DeleteAsync(id, ct);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            return Ok(await categoryService.GetByIdAsync(id, ct));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await categoryService.GetAllAsync(ct));
        }
    }
}
