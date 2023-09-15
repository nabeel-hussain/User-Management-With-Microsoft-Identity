using UM.Domain.SlimEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Users.Commands.UpdateUser
{
    public sealed record UpdateUserCommand(Guid Id,string FirstName,string LastName, string UserName, string Email, List<string> Roles) : IRequest<UpdateUserCommandResponse>;
}
