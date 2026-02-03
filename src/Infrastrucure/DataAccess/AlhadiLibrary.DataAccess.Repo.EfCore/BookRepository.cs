using AlhadiLibrary.Db.SqlServer.EfCore.DbContext;
using AlhadiLibrary.Domain.Core.BookAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using AlhadiLibrary.Domain.Core.BookAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AlhadiLibrary.DataAccess.Repo.EfCore;

public class BookRepository(AppDbContext context, IMapper mapper) : IBookRepository
{
    public async Task<int> CreateAsync(CreateBookDto dto, CancellationToken ct)
    {
        var book = mapper.Map<Book>(dto);

        context.Books.Add(book);
        await context.SaveChangesAsync(ct);

        return book.Id;
    }
    public async Task UpdateAsync(UpdateBookDto dto, CancellationToken ct)
    {
        var book = await context.Books
            .Include(x => x.Authors)
            .Include(x => x.Translators)
            .FirstAsync(x => x.Id == dto.Id, ct);

        mapper.Map(dto, book);

        book.Authors.Clear();
        book.Translators.Clear();

        book.Authors = dto.AuthorIds
            .Select(id => new BookAuthor { AuthorId = id })
            .ToList();

        book.Translators = dto.TranslatorIds
            .Select(id => new BookTranslator { TranslatorId = id })
            .ToList();

        await context.SaveChangesAsync(ct);
    }


    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var book = await context.Books.FirstAsync(x => x.Id == id, ct);
        context.Books.Remove(book);
        await context.SaveChangesAsync(ct);
    }

    public async Task<BookDto> GetByIdAsync(int id, CancellationToken ct)
    {
        return await context.Books
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .FirstAsync(ct);
    }
    public async Task<List<BookDto>> GetAllAsync(CancellationToken ct)
    {
        return await context.Books
            .AsNoTracking()
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }
}