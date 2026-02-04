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

    public async Task<List<BookDto>> SearchAsync(SearchBookDto filter, CancellationToken ct)
    {
        IQueryable<Book> query = context.Books
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Authors)
                .ThenInclude(x => x.Author)
            .Include(x => x.Translators)
                .ThenInclude(x => x.Translator);

        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(x =>
                x.Title.Contains(filter.Title));
        }

        if (!string.IsNullOrWhiteSpace(filter.AuthorFirstName))
        {
            query = query.Where(x =>
                x.Authors.Any(a =>
                    a.Author.FirstName.Contains(filter.AuthorFirstName)));
        }

        if (!string.IsNullOrWhiteSpace(filter.AuthorLastName))
        {
            query = query.Where(x =>
                x.Authors.Any(a =>
                    a.Author.LastName.Contains(filter.AuthorLastName)));
        }

        if (!string.IsNullOrWhiteSpace(filter.TranslatorFirstName))
        {
            query = query.Where(x =>
                x.Translators.Any(t =>
                    t.Translator.FirstName.Contains(filter.TranslatorFirstName)));
        }

        if (!string.IsNullOrWhiteSpace(filter.TranslatorLastName))
        {
            query = query.Where(x =>
                x.Translators.Any(t =>
                    t.Translator.LastName.Contains(filter.TranslatorLastName)));
        }

        if (filter.CategoryId.HasValue)
        {
            query = query.Where(x =>
                x.CategoryId == filter.CategoryId.Value);
        }

        if (filter.MinPrice.HasValue)
        {
            query = query.Where(x =>
                x.Price >= filter.MinPrice.Value);
        }

        if (filter.MaxPrice.HasValue)
        {
            query = query.Where(x =>
                x.Price <= filter.MaxPrice.Value);
        }

        if (filter.MinPageCount.HasValue)
        {
            query = query.Where(x =>
                x.PageCount >= filter.MinPageCount.Value);
        }

        if (filter.MaxPageCount.HasValue)
        {
            query = query.Where(x =>
                x.PageCount <= filter.MaxPageCount.Value);
        }

        return await query
            .Select(x => mapper.Map<BookDto>(x))
            .ToListAsync(ct);
    }
}