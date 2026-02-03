using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.AppService.Books.Queries;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlhadiLibrary.Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(IMediator mediator) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto, CancellationToken ct)
        {
            var command = new CreateBookCommand { Dto = dto };
            var id = await mediator.Send(command, ct);
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookDto dto, CancellationToken ct)
        {
            var command = new UpdateBookCommand { Dto = dto };
            await mediator.Send(command, ct);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var command = new DeleteBookCommand { Id = id };
            await mediator.Send(command, ct);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            var query = new GetBookByIdQuery { Id = id };
            var result = await mediator.Send(query, ct);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var query = new GetAllBooksQuery();
            var result = await mediator.Send(query, ct);
            return Ok(result);
        }
    }
}
