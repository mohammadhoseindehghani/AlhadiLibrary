using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class UpdateBookCommandHandler(IBookService bookService) : IRequestHandler<UpdateBookCommand, Unit>
{
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await bookService.UpdateAsync(request.Dto, cancellationToken);
        return Unit.Value;
    }
}