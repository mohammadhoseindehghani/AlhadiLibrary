using AlhadiLibrary.Domain.Core.BookAgg.DTOs;

namespace AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;

public interface IBookRepository
{
    Task<int> CreateAsync(CreateBookDto dto, CancellationToken ct);
    Task UpdateAsync(UpdateBookDto dto, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);

    Task<BookDto> GetByIdAsync(int id, CancellationToken ct);
    Task<List<BookDto>> GetAllAsync(CancellationToken ct);
    Task<List<BookDto>> SearchAsync(SearchBookDto filter, CancellationToken ct);
}