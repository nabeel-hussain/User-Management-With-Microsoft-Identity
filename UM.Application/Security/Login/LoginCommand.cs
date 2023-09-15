using MediatR;

namespace UM.Application.Security.Login
{
    public sealed record LoginCommand(
        string Email,
        string Password) : IRequest<LoginCommandResponse>;
}
