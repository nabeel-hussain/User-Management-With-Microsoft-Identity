using UM.Domain.Entities;

namespace UM.Application.Roles.Commands.CreateRole;

public class CreateRoleResponse
{
    public CreateRoleResponse(Role role)
    {
        this.role = role;
    }

    public Role role { get; set; }

}
