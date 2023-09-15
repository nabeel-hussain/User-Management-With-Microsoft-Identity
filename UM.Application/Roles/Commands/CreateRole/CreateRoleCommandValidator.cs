using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommandValidator: AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator() 
        { 
            RuleFor(x=>x.RoleName).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.HotelId).NotEmpty();
            RuleFor(x => x.Permissions).Must(x => x.Count > 0).WithMessage("At least one permission requried for rule");
        }

    }
}
