using UM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Interfaces.Authentication
{
    public interface IPermission
    {
        Task<HashSet<string>> GetUserPermissionsAsync(Guid userId);
        Task AddPermissions(List<Permission> permissions);
    }
}
