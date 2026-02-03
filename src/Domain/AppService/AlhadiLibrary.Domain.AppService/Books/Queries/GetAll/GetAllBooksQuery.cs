using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Queries.GetAll;

public class GetAllBooksQuery : IRequest<List<BookDto>>
{
}