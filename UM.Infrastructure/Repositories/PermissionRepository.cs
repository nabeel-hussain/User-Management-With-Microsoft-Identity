using UM.Domain.Entities;
using UM.Domain.Interfaces.Authentication;
using UM.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Infrastructure.Repositories
{
    public class PermissionRepository : IPermission
    {
        readonly HMSDbContext _hmsDbContext;
        public PermissionRepository(HMSDbContext hmsDbContext)
        {
            _hmsDbContext = hmsDbContext;
        }

        public async Task AddPermissions(List<Permission> permissions)
        {
            await _hmsDbContext.Set<Permission>().AddRangeAsync(permissions);
            await _hmsDbContext.SaveChangesAsync();
        }

        public async Task<HashSet<string>> GetUserPermissionsAsync(Guid userId)
        {
           return new HashSet<string>(){ "Read","Write"};
        }
    }
}
