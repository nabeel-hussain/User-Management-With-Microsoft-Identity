using FluentValidation;
using UM.Domain.Constants;

namespace UM.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.FirstName).NotEmpty();
        RuleFor(v => v.LastName).NotEmpty();
        RuleFor(v => v.UserName).NotEmpty().MinimumLength(ValidationConstants.User.MinUserNameLength);
        RuleFor(x => x.Roles).Must(roles => roles.Any()).WithMessage("Select at least one role for the user");
    }
}
