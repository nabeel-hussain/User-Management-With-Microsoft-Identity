using UM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Interfaces.Authentication
{
    public interface IJwtTokenManager
    {
        public Task<string> GenerateToken(User user, List<Role> roles);
    }
}
