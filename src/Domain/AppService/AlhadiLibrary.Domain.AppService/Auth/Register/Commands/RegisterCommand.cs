using AlhadiLibrary.Domain.Core.UserAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Auth.Register.Commands;

public class RegisterCommand : IRequest<AuthResultDto>
{
    public string FirstName { get; init; } 
    public string LastName { get; init; } 
    public string Email { get; init; } 
    public string Password { get; init; } 
    public string MobileNumber { get; init; }
}

