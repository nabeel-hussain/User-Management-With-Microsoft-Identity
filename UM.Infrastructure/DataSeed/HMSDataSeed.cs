using Azure.Core;
using UM.Domain.Constants;
using UM.Domain.Entities;
using UM.Domain.Interfaces;
using UM.Domain.Interfaces.Authentication;
using System.Data;

namespace UM.Infrastructure.DataSeed;

public class HMSDataSeed : IDataSeed
{
    readonly IUser _userRepository;
    readonly IRole _roleRepository;
    readonly IPermission _permissionRepository;
    public HMSDataSeed(IUser userRepository, IRole roleRepository, IPermission permissionRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _permissionRepository = permissionRepository;

    }

    public Task HotelDataSeed()
    {
        throw new NotImplementedException();
    }

    public async Task SecurityDataSeed()
    {
        try
        {

            //IEnumerable<Permission> permissions = Enum
            //    .GetValues<Domain.Enums.Permission>()
            //    .Select(p => new Permission
            //    {
            //        Id = (int)p,
            //        Name = p.ToString()
            //    });
            //await _permissionRepository.AddPermissions(permissions.ToList());

            if (!(await _userRepository.GetAllUsers()).Any())
            {
                User user1 = User.CreateNewUser(Guid.NewGuid(), "Nabeel", "Hussain","luxkyshan@gmail.com", "nabeel.hussain");
                User user2 = User.CreateNewUser(Guid.NewGuid(), "Tehseen", "Ahmed Khan", "Tehseen.ahemd@gmail.com", "Tehseen.Ahmed");

                Role role1 = Role.CreateRole("Admin", "Admin with full access", Domain.Enums.RoleStatus.Active, Guid.NewGuid());
                Role role2 = Role.CreateRole("Viewer", "No editing access", Domain.Enums.RoleStatus.Active, Guid.NewGuid());
                List<RoleClaim> role1Claims = new List<RoleClaim>();
                role1Claims.Add(new RoleClaim { RoleId = role1.Id, ClaimType = CustomClaimTypes.Permissions, ClaimValue = "Read" });
                role1Claims.Add(new RoleClaim { RoleId = role1.Id, ClaimType = CustomClaimTypes.Permissions, ClaimValue = "Write" });
                List<RoleClaim> role2Claims = new List<RoleClaim>();
                role2Claims.Add(new RoleClaim { RoleId = role2.Id, ClaimType = CustomClaimTypes.Permissions, ClaimValue = "Read" });
                await _roleRepository.AddRole(role1);
                await _roleRepository.AddRole(role2);
                await _roleRepository.AddRolesClaim(role1Claims);
                await _roleRepository.AddRolesClaim(role2Claims);
                //userRepository.AddUser(user,pass)
                await _userRepository.AddUser(user1, "Pakistan@10", new List<string> { role1.Id.ToString() });
                await _userRepository.AddUser(user2, "Pakistan@10", new List<string> { role2.Id.ToString() });

            }
        }
        catch (Exception ex)
        {

        }

    }
}
