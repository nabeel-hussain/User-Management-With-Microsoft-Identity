using UM.Api.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;
using UM.Domain.Entities;
using UM.Application.Security.Login;
using UM.Application.Security.ChangePassword;

namespace UM.Api.Controllers
{
    public class SecurityController : HMSBaseController
    {
        [HttpPost]
        public async Task<LoginCommandResponse> Login(LoginCommand loginCommand)
        {
           return await Mediator.Send(loginCommand);
        }
        [HttpPut]
        public async Task ChangePassword(ChangePasswordCommand changePasswordCommand)
        {
             await Mediator.Send(changePasswordCommand);
        }
    }
}
