using AlhadiLibrary.Domain.AppService.Books.Commands;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return await bookRepository.CreateAsync(request.Dto, cancellationToken);
    }
}