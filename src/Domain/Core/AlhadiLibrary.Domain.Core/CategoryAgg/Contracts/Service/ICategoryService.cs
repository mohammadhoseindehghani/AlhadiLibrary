using AlhadiLibrary.Domain.Core.CategoryAgg.DTOs;

namespace AlhadiLibrary.Domain.Core.CategoryAgg.Contracts.Service;

public interface ICategoryService
{
    Task<int> CreateAsync(CreateCategoryDto dto, CancellationToken ct);
    Task UpdateAsync(UpdateCategoryDto dto, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);

    Task<CategoryDto> GetByIdAsync(int id, CancellationToken ct);
    Task<List<CategoryDto>> GetAllAsync(CancellationToken ct);
}