using UM.Domain.Constants;
using UM.Domain.Exceptions;
using UM.Domain.Interfaces;
using MediatR;

namespace UM.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    readonly IRole _roleRepository;
    public DeleteRoleCommandHandler(IRole roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleById(request.Id);
        if (role == null)
        {
            throw new RoleNotFoundException(ValidationMessages.Role.RoleNotFound);
        }
        if (role.UserRoles != null && role.UserRoles.Count > 0)
        {
            throw new RoleIsAssignedToUsersException(ValidationMessages.Role.RoleIsAssignedToUsers);
        }
        await _roleRepository.DeleteRole(role);
    }
}
