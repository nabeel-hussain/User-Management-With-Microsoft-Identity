using UM.Api.Controllers.Shared;
using UM.Application.Users.Commands.CreateUser;
using UM.Application.Users.Commands.UpdateUser;
using UM.Domain.Enums;
using UM.Domain.SlimEntities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UM.Infrastructure.Authentication;

namespace UM.Api.Controllers
{
    public class UserController : HMSBaseController
    {
        [HasPermission(Permission.Write)]
        [HttpPost]
        public async Task<CreateUserResponse> AddUser(CreateUserCommand createUserCommand)
        {
           return await Mediator.Send(createUserCommand);
           
        }

        [HasPermission(Permission.Write)]
        [HttpPut]
        public async Task<UpdateUserCommandResponse> UpdateUser(UpdateUserCommand updateUserCommand)
        {
             return await Mediator.Send(updateUserCommand);

        }

        [HasPermission(Permission.Write)]
        [HttpDelete]
        public async Task<CreateUserResponse> DeleteUser(CreateUserCommand createUserCommand)
        {
            return await Mediator.Send(createUserCommand);

        }
        [HttpGet]
        public async Task<CreateUserResponse> GetUserById(CreateUserCommand createUserCommand)
        {
            return await Mediator.Send(createUserCommand);
        }
    }
}
