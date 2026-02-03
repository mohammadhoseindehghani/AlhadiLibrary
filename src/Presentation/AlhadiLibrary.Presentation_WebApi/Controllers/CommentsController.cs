using AlhadiLibrary.Domain.AppService.Comments.Commands.Approve;
using AlhadiLibrary.Domain.AppService.Comments.Commands.Create;
using AlhadiLibrary.Domain.AppService.Comments.Queries.GetApprovedByBookId;
using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlhadiLibrary.Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController(IMediator mediator) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentDto dto, CancellationToken ct)
        {
            var userId = int.Parse(User.FindFirst("sub")?.Value ?? "0");
            var command = new CreateCommentCommand { UserId = userId, Dto = dto };
            await mediator.Send(command, ct);
            return Ok();
        }

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBook(int bookId, CancellationToken ct)
        {
            var query = new GetApprovedByBookIdQuery { BookId = bookId };
            var result = await mediator.Send(query, ct);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id, CancellationToken ct)
        {
            var command = new ApproveCommentCommand { CommentId = id };
            await mediator.Send(command, ct);
            return NoContent();
        }
    }

}
