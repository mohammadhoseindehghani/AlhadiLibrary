using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Books.Commands.Create;

public class CreateBookCommand : IRequest<int>
{
    public CreateBookDto Dto { get; set; }
}