using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Queries.GetById;

public class GetBookByIdQuery : IRequest<BookDto>
{
    public int Id { get; set; }
}