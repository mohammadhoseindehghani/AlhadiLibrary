using AlhadiLibrary.Domain.Core.UserAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Auth.Login.Commands;

public class LoginCommand : IRequest<AuthResultDto>
{
    public string Email { get; init; } 
    public string Password { get; init; } 
}
