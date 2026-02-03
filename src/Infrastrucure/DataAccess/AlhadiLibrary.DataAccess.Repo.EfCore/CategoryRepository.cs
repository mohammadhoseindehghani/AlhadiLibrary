using AlhadiLibrary.Db.SqlServer.EfCore.DbContext;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;
using AlhadiLibrary.Domain.Core.CategoryAgg.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AlhadiLibrary.DataAccess.Repo.EfCore;

public class CategoryRepository(AppDbContext context, IMapper mapper) : ICategoryRepository
{
    public async Task<int> CreateAsync(CreateCategoryDto dto, CancellationToken ct)
    {
        var category = mapper.Map<Category>(dto);

        context.Categories.Add(category);
        await context.SaveChangesAsync(ct);

        return category.Id;
    }


    public async Task UpdateAsync(UpdateCategoryDto dto, CancellationToken ct)
    {
        var category = await context.Categories
            .FirstAsync(x => x.Id == dto.Id, ct);

        mapper.Map(dto, category);

        await context.SaveChangesAsync(ct);
    }


    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var category = await context.Categories
            .FirstAsync(x => x.Id == id, ct);

        context.Categories.Remove(category);
        await context.SaveChangesAsync(ct);
    }

    public async Task<CategoryDto> GetByIdAsync(int id, CancellationToken ct)
    {
        return await context.Categories
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
            .FirstAsync(ct);
    }


    public async Task<List<CategoryDto>> GetAllAsync(CancellationToken ct)
    {
        return await context.Categories
            .AsNoTracking()
            .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }

}