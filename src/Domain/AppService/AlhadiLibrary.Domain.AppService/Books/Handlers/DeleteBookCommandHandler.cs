using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class DeleteBookCommandHandler(IBookService bookService) : IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await bookService.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}