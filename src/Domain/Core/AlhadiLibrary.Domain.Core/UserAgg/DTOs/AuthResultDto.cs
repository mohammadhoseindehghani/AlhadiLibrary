namespace AlhadiLibrary.Domain.Core.UserAgg.DTOs;

public record AuthResultDto(
    int UserId,
    string Token,
    DateTime ExpireAt
);