using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Commands.Update;

public class UpdateBookCommand : IRequest<Unit>
{
    public UpdateBookDto Dto { get; set; }
}