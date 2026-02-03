using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Commands;

public class DeleteBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
}