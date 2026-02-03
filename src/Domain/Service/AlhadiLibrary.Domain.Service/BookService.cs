using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;

namespace AlhadiLibrary.Domain.Service;

public class BookService(IBookRepository bookRepo) : IBookService
{
    public async Task<int> CreateAsync(CreateBookDto dto, CancellationToken ct)
    {
        return await bookRepo.CreateAsync(dto, ct);
    }

    public async Task UpdateAsync(UpdateBookDto dto, CancellationToken ct)
    {
        await bookRepo.UpdateAsync(dto, ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        await bookRepo.DeleteAsync(id, ct);
    }

    public async Task<BookDto> GetByIdAsync(int id, CancellationToken ct)
    {
        return await bookRepo.GetByIdAsync(id, ct);
    }

    public async Task<List<BookDto>> GetAllAsync(CancellationToken ct)
    {
        return await bookRepo.GetAllAsync(ct);
    }
}