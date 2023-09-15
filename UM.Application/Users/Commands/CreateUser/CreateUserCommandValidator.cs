using FluentValidation;
using UM.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UM.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.FirstName).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
            RuleFor(v => v.Username).NotEmpty().MinimumLength(ValidationConstants.User.MinUserNameLength);
            RuleFor(v => v.Email).EmailAddress();
            RuleFor(v => v.Password).NotEmpty()
                                    .MinimumLength(ValidationConstants.User.MinPasswordLength)
                                    .MaximumLength(ValidationConstants.User.MaxPasswordLength);
 //                                   .Must(x => HasLowerUpperDigitAndSpecialChar(x));
        }

        private bool HasLowerUpperDigitAndSpecialChar(string password)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return lowercase.IsMatch(password) && uppercase.IsMatch(password) && digit.IsMatch(password) && symbol.IsMatch(password);
        }
    }
}
