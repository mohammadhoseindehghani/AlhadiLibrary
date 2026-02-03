namespace AlhadiLibrary.Domain.Core.UserAgg.DTOs;

public class AuthResultDto
{
    public int UserId { get; set; }
    public string Token { get; set; } 
    public DateTime ExpireAt { get; set; }
}