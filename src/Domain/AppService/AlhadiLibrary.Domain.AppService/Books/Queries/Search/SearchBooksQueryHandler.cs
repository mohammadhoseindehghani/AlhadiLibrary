using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Queries.Search;

public class SearchBooksQueryHandler(IBookRepository bookRepository) : IRequestHandler<SearchBooksQuery, List<BookDto>>
{
    public async Task<List<BookDto>> Handle(SearchBooksQuery request, CancellationToken ct)
    {

        NormalizeAuthorNames(request.Filter);
        NormalizeTranslatorNames(request.Filter);

        return await bookRepository.SearchAsync(
            request.Filter, ct);
    }

    private static void NormalizeAuthorNames(SearchBookDto filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.AuthorFirstName)
            && filter.AuthorFirstName.Contains(" "))
        {
            var parts = filter.AuthorFirstName
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2)
            {
                filter.AuthorFirstName = parts[0];
                filter.AuthorLastName = parts[1];
            }
        }
    }

    private static void NormalizeTranslatorNames(SearchBookDto filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.TranslatorFirstName)
            && filter.TranslatorFirstName.Contains(" "))
        {
            var parts = filter.TranslatorFirstName
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2)
            {
                filter.TranslatorFirstName = parts[0];
                filter.TranslatorLastName = parts[1];
            }
        }
    }
}
