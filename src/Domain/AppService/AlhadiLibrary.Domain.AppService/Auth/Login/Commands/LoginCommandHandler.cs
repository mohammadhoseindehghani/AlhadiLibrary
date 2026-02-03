using AlhadiLibrary.Domain.AppService.Auth.Register.Commands;
using AlhadiLibrary.Domain.Core.UserAgg.Contracts.Service;
using AlhadiLibrary.Domain.Core.UserAgg.DTOs;
using MediatR;

namespace AlhadiLibrary.Domain.AppService.Auth.Login.Commands;

public class LoginCommandHandler(IIdentityService identityService) : IRequestHandler<LoginCommand, AuthResultDto>
{
    public async Task<AuthResultDto> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new LoginDto
        {
            Email = request.Email,
            Password = request.Password
        };

        return await identityService.LoginAsync(dto, cancellationToken);
    }
}


