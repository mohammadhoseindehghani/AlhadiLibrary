using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Queries.Search;

public class SearchBooksQuery : IRequest<List<BookDto>>
{
    public SearchBookDto Filter { get; set; } = new();
}