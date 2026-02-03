using AlhadiLibrary.Domain.Core.UserAgg.DTOs;

namespace AlhadiLibrary.Domain.Core.UserAgg.Contracts.Service;

public interface IIdentityService
{
    Task<AuthResultDto> RegisterAsync(RegisterDto dto,CancellationToken ct);
    Task<AuthResultDto> LoginAsync(LoginDto dto);
}
