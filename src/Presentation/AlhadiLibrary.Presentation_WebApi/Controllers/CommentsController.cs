using AlhadiLibrary.Domain.Core.CommentAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlhadiLibrary.Presentation_WebApi.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentDto dto, CancellationToken ct)
        {
            var userId = int.Parse(User.FindFirst("sub").Value);

            await commentService.AddAsync(dto, userId, ct);
            return Ok();
        }

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBook(int bookId, CancellationToken ct)
        {
            return Ok(await commentService.GetApprovedByBookIdAsync(bookId, ct));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id, CancellationToken ct)
        {
            await commentService.ApproveAsync(id, ct);
            return NoContent();
        }
    }

}
