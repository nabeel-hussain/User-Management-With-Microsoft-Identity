using UM.Domain.Constants;
using UM.Domain.Entities;
using UM.Domain.Enums;
using UM.Domain.Interfaces;
using MediatR;

namespace UM.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
{
    readonly IRole _roleRepository;
    public CreateRoleCommandHandler(IRole roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = Role.CreateRole(request.RoleName, request.Description, RoleStatus.Active, request.HotelId);
        List<RoleClaim> roleClaims = new List<RoleClaim>();
        foreach (var item in request.Permissions)
        {
            roleClaims.Add(new RoleClaim { RoleId = role.Id, ClaimType = CustomClaimTypes.Permissions, ClaimValue = item });
        }
        await _roleRepository.AddRole(role);
        await _roleRepository.AddRolesClaim(roleClaims);
        var response = new CreateRoleResponse(role);
        return response;
    }
}
