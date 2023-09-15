using UM.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Roles.Commands.UpdateRole
{
    public sealed record UpdateRoleCommand(Guid Id,string Name, string Description, List<string> Permissions, RoleStatus Status):IRequest;
}
