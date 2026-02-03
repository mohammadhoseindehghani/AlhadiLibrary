using AlhadiLibrary.Domain.Core.UserAgg.Entities;

namespace AlhadiLibrary.Domain.Core.UserAgg.Contracts.Service;

public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser applicationUser);
}
