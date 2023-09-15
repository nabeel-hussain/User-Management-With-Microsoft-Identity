using FluentValidation;

namespace UM.Application.Security.ChangePassword
{
    public class ChangePasswordCommandValidator: AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.NewPassword).NotEmpty();
            RuleFor(x=>x.OldPassword).NotEmpty();
        }
    }
}
