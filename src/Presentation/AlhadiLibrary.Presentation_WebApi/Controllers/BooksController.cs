using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlhadiLibrary.Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(IBookService bookService)
        : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto, CancellationToken ct)
        {
            var id = await bookService.CreateAsync(dto, ct);
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookDto dto, CancellationToken ct)
        {
            await bookService.UpdateAsync(dto, ct);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await bookService.DeleteAsync(id, ct);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            return Ok(await bookService.GetByIdAsync(id, ct));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await bookService.GetAllAsync(ct));
        }
    }

}
