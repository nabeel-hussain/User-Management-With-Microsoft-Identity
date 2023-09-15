using UM.Api.Controllers.Shared;
using UM.Application.Roles.Commands.CreateRole;
using UM.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using UM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using UM.Application.Roles.Commands.UpdateRole;
using UM.Application.Roles.Commands.DeleteRole;

namespace UM.Api.Controllers
{
    public class RoleController : HMSBaseController
    {
        [HttpPost]
        [HasPermission(Permission.Write)]
        public async Task<CreateRoleResponse> AddRole(CreateRoleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [HasPermission(Permission.Write)]
        public async Task UpdateRole(UpdateRoleCommand command)
        {
            await Mediator.Send(command);
        }
        [HasPermission(Permission.Write)]
        [HttpPost]
        public async Task DeleteRole(DeleteRoleCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
