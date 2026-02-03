using AlhadiLibrary.Domain.AppService.Books.Queries;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class GetAllBooksQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await bookRepository.GetAllAsync(cancellationToken);
    }
}