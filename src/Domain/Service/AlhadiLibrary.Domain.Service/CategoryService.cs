using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Data;
using AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;

namespace AlhadiLibrary.Domain.Service;

public class CategoryService(ICategoryRepository categoryRepo) : ICategoryService
{
    public async Task<int> CreateAsync(CreateCategoryDto dto, CancellationToken ct)
    {
        return await categoryRepo.CreateAsync(dto, ct);
    }

    public async Task UpdateAsync(UpdateCategoryDto dto, CancellationToken ct)
    { 
        await categoryRepo.UpdateAsync(dto, ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        await categoryRepo.DeleteAsync(id, ct);
    }

    public async Task<CategoryDto> GetByIdAsync(int id, CancellationToken ct)
    {
        return await categoryRepo.GetByIdAsync(id, ct);
    }

    public async Task<List<CategoryDto>> GetAllAsync(CancellationToken ct)
    {
        return await categoryRepo.GetAllAsync(ct);
    }
}