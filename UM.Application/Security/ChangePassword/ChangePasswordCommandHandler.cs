using UM.Domain.Constants;
using UM.Domain.Exceptions;
using UM.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UM.Application.Security.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        readonly IUser userRepository;
        public ChangePasswordCommandHandler(IUser userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmail(request.Email);
            if (user == null)
                throw new UserNotFoundException(ValidationMessages.User.UserNotFound);
            var result = await userRepository.ChangePassword(user, request.OldPassword, request.NewPassword);
            if (!result.Succeeded)
                throw new PasswordChangeFailedException($"{String.Join("|", result.Errors.Select(x => x.Description).Select(x => x.ToString()))}{ValidationMessages.User.PasswordChangeFailed}");
        }
    }
}
