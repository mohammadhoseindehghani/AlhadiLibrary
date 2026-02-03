using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Queries;

public class GetAllBooksQuery : IRequest<List<BookDto>>
{
}