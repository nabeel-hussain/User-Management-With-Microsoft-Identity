using UM.Domain.Entities;
using UM.Domain.SlimEntities;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Security.Login
{
    public sealed record LoginCommandResponse(SlimUser User,string AccessToken);
}
