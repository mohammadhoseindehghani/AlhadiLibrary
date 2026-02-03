using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class UpdateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, Unit>
{
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await bookRepository.UpdateAsync(request.Dto, cancellationToken);
        return Unit.Value;
    }
}