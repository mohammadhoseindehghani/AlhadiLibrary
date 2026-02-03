namespace AlhadiLibrary.Domain.Core.UserAgg.DTOs;

public record RegisterDto(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string MobileNumber
);