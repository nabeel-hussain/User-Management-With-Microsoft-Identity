using UM.Domain.Constants;
using UM.Domain.Exceptions;
using UM.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Roles.Commands.UpdateRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        readonly IRole _roleRepository;
        public DeleteRoleCommandHandler(IRole roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role =await  _roleRepository.GetRoleById(request.Id);
            if (role == null)
            {
                throw new RoleNotFoundException(ValidationMessages.Role.RoleNotFound);
            }
            role.Description = request.Description;
            role.Name = request.Name;
            role.Status = request.Status;
            await _roleRepository.UpdateRole(role,request.Permissions);
        }
    }
}
