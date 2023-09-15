using Azure.Core;
using UM.Domain.Constants;
using UM.Domain.Entities;
using UM.Domain.Interfaces;
using UM.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace UM.Infrastructure.Repositories;

public class RoleRepository : IRole
{
    readonly RoleManager<Role> _roleManager;
    readonly HMSDbContext _hmsDbContext;
    public RoleRepository(HMSDbContext hmsDbContext, RoleManager<Role> roleManager)
    {
        _hmsDbContext = hmsDbContext;
        _roleManager = roleManager;
    }
    public async Task AddRole(Role role)
    {
        await _roleManager.CreateAsync(role);
    }

    public async Task AddRolesClaim(List<RoleClaim> roleClaims)
    {
        await _hmsDbContext.RoleClaims.AddRangeAsync(roleClaims);
        await _hmsDbContext.SaveChangesAsync();
    }

    public async Task DeleteRole(Role role)
    {
        await _roleManager.DeleteAsync(role);
        await _hmsDbContext.SaveChangesAsync();
    }

    public async Task<List<Role>> GetAllRoles()
    {
        return await _hmsDbContext.Roles.ToListAsync<Role>();
    }

    public async Task<Role> GetRoleById(Guid id)
    {
        var role = await _hmsDbContext.Roles.FindAsync(id);
        var role1 = _hmsDbContext.Roles.FirstOrDefault(x=>x.Id==id);
        role.UserRoles = _hmsDbContext.UserRoles.Where(x=>x.RoleId==id).ToList();
        return await _roleManager.FindByIdAsync(id.ToString());
    }

    public async Task<List<Claim>> GetRoleClaims(Role role)
    {
        return (await _roleManager.GetClaimsAsync(role)).ToList();
    }

    public Task<List<Role>> GetRolesByHotelId(Guid hotelId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRole(Role role, List<string> Permissions)
    {
        List<RoleClaim> roleClaims = await _hmsDbContext.RoleClaims.Where(r => r.RoleId == role.Id && r.ClaimType == CustomClaimTypes.Permissions).ToListAsync();
        _hmsDbContext.RoleClaims.RemoveRange(roleClaims);
        List<RoleClaim> newRoleClaims = new List<RoleClaim>();
        foreach (var permission in Permissions)
        {
            newRoleClaims.Add(new RoleClaim { RoleId = role.Id, ClaimType = CustomClaimTypes.Permissions, ClaimValue = permission });
        }
        await _roleManager.UpdateAsync(role);
        await _hmsDbContext.RoleClaims.AddRangeAsync(newRoleClaims);
        await _hmsDbContext.SaveChangesAsync();

    }
}
