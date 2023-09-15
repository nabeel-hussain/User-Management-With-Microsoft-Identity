using UM.Domain.Entities;
using System.Security.Claims;

namespace UM.Domain.Interfaces;

public interface IRole
{
    public Task AddRole(Role role);
    public Task DeleteRole(Role role);
    public Task UpdateRole(Role role,List<string> Permissions);
    public Task<Role> GetRoleById(Guid id);
    public Task<List<Role>> GetRolesByHotelId(Guid hotelId);
    public Task<List<Role>> GetAllRoles();
    public Task AddRolesClaim(List<RoleClaim> roleClaims);
    public Task<List<Claim>> GetRoleClaims(Role role);
}
