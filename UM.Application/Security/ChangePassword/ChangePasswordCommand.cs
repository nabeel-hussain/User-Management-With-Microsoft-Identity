using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Security.ChangePassword
{
    public sealed record ChangePasswordCommand(string Email,string OldPassword,string NewPassword): IRequest;
}
