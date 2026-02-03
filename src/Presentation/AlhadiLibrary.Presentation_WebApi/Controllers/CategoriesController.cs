using AlhadiLibrary.Domain.AppService.Categories.Commands.Create;
using AlhadiLibrary.Domain.AppService.Categories.Commands.Delete;
using AlhadiLibrary.Domain.AppService.Categories.Commands.Update;
using AlhadiLibrary.Domain.AppService.Categories.Queries.GetAll;
using AlhadiLibrary.Domain.AppService.Categories.Queries.GetById;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlhadiLibrary.Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto, CancellationToken ct)
        {
            var command = new CreateCategoryCommand { Dto = dto };
            var id = await mediator.Send(command, ct);
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto, CancellationToken ct)
        {
            var command = new UpdateCategoryCommand() { Dto = dto };
            await mediator.Send(command, ct);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var command = new DeleteCategoryCommand() { Id = id };
            await mediator.Send(command, ct);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
        {
            var query = new GetCategoryByIdQuery() { Id = id };
            var result = await mediator.Send(query, ct);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var query = new GetAllCategoryQuery();
            var result = mediator.Send(query, ct);
            return Ok(result);
        }
    }
}
