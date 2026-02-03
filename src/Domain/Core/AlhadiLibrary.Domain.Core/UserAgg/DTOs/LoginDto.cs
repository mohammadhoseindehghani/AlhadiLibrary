namespace AlhadiLibrary.Domain.Core.UserAgg.DTOs;

public record LoginDto(
    string Email,
    string Password
);