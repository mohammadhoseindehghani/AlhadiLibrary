using AlhadiLibrary.Domain.Core.UserAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.UserAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Auth.Register.Commands;

public class RegisterCommandHandler(IIdentityService identityService) : IRequestHandler<RegisterCommand, AuthResultDto>
{
    public async Task<AuthResultDto> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new RegisterDto
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            MobileNumber = request.MobileNumber
        };

        return await identityService.RegisterAsync(dto, cancellationToken);
    }
}

