using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Commands.Delete;

public class DeleteBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
}