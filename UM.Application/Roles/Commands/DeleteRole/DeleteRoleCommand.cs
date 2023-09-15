using MediatR;

namespace UM.Application.Roles.Commands.DeleteRole;

public sealed record DeleteRoleCommand(Guid Id):IRequest;
