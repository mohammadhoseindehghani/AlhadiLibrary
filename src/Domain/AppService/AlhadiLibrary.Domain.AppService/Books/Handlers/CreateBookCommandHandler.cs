using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class CreateBookCommandHandler(IBookService bookService) : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return await bookService.CreateAsync(request.Dto, cancellationToken);
    }
}