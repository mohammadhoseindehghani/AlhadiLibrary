using AlhadiLibrary.Db.SqlServer.EfCore.DbContext;
using AlhadiLibrary.Domain.Core.UserAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.UserAgg.DTOs;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlhadiLibrary.Db.SqlServer.EfCore.Identity.Service;

public class IdentityService(
    UserManager<ApplicationUser> userManager,
    IJwtTokenGenerator jwtTokenGenerator,
    AppDbContext context)
    : IIdentityService
{
    public async Task<AuthResultDto> RegisterAsync(RegisterDto dto, CancellationToken ct)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);

        ApplicationUser identityUser = null;

        try
        {
            identityUser = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var identityResult =
                await userManager.CreateAsync(identityUser, dto.Password);

            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.First().Description);

            var user = new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                IdentityUserId = identityUser.Id,
                Role = UserRoleEnum.Customer
            };

            context.DomainUsers.Add(user);
            await context.SaveChangesAsync(ct);

            await transaction.CommitAsync(ct);

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthResultDto
            {
                UserId = user.Id,
                Token = token,
                ExpireAt = DateTime.UtcNow.AddHours(2)
            };
        }
        catch
        {
            await transaction.RollbackAsync(ct);

            if (identityUser != null)
                await userManager.DeleteAsync(identityUser);

            throw;
        }
    }

    public async Task<AuthResultDto> LoginAsync(LoginDto dto, CancellationToken ct)
    {
        var identityUser = await userManager.FindByEmailAsync(dto.Email);
        if (identityUser == null)
            throw new Exception("Invalid credentials");

        var isValid =
            await userManager.CheckPasswordAsync(identityUser, dto.Password);

        if (!isValid)
            throw new Exception("Invalid credentials");

        var user = await context.Users
            .AsNoTracking()
            .FirstAsync(x => x.IdentityUserId == identityUser.Id, ct);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthResultDto
        {
            UserId = user.Id,
            Token = token,
            ExpireAt = DateTime.UtcNow.AddHours(2)
        };
    }
}
