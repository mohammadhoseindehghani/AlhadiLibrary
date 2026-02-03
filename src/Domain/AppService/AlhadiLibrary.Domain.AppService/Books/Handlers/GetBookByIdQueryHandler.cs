using AlhadiLibrary.Domain.AppService.Books.Queries;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Handlers;

public class GetBookByIdQueryHandler(IBookService bookService) : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await bookService.GetByIdAsync(request.Id, cancellationToken);
    }
}