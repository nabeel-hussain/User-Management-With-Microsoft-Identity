using MediatR;

namespace UM.Application.Roles.Commands.CreateRole;

public sealed record CreateRoleCommand(
string RoleName,
string Description,
Guid HotelId,
List<string> Permissions
) : IRequest<CreateRoleResponse>;
