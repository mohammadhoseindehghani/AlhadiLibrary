using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await bookRepository.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}