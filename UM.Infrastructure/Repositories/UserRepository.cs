using Azure.Core;
using UM.Domain.Entities;
using UM.Domain.Interfaces;
using UM.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UM.Infrastructure.Repositories;

public class UserRepository : IUser
{
    readonly HMSDbContext _hmsDbContext;
    readonly UserManager<User> _userManager;
    readonly RoleManager<Role> _roleManager;
    readonly SignInManager<User> _signInManager;
    readonly IRole _roleRepository;
    public UserRepository(HMSDbContext hmsDbContext, UserManager<User> userManager, RoleManager<Role> roleManager,IRole roleRepository, SignInManager<User> signInManager)
    {
        _hmsDbContext = hmsDbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _roleRepository = roleRepository;
        _signInManager = signInManager;
    }
    public async Task AddUser(User user,string password,List<string> roles)
    {
        await _userManager.AddPasswordAsync(user, password);
        var rolesIds = roles.Select(x => new Guid(x)).ToArray();
        var rolesList = (await _roleRepository.GetAllRoles()).Where(x => rolesIds.Contains(x.Id)).ToList();
        await _userManager.AddToRolesAsync(user, rolesList.Select(x => x.Name).ToArray());
        await _hmsDbContext.Users.AddAsync(user);
        await _hmsDbContext.SaveChangesAsync();
    }
    public async Task<IdentityResult> ChangePassword(User user, string oldPassword, string newPassword)
    {
        var identityResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        return identityResult;
    }

    public async Task<SignInResult> CheckPasswordSignIn(User user,string password)
    {
        return await _signInManager.CheckPasswordSignInAsync(user, password, true);
    }

    public Task DeactivateUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllUsers( )
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return (await _hmsDbContext.Users.ToListAsync()).FirstOrDefault(user => user.Email == email);
    }

    public async Task<User> GetUserById(Guid id)
    {
        return (await _hmsDbContext.Users.ToListAsync()).FirstOrDefault(user => user.Id == id);
    }

    public async Task<List<string>> GetUserRoles(User user)
    {
        return (await _userManager.GetRolesAsync(user)).ToList();
    }

    public Task<List<User>> GetUsersByHotel(Guid hotelId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUser(User user, List<string> roles)
    {
        var rolesIds = roles.Select(x => new Guid(x)).ToArray();
        var rolesList = (await _roleRepository.GetAllRoles()).Where(x => rolesIds.Contains(x.Id)).ToList();
        var userRolesList =   _hmsDbContext.UserRoles.Where(x=>rolesIds.Contains(x.RoleId)).ToList();
        _hmsDbContext.UserRoles.RemoveRange(userRolesList);
        await _userManager.AddToRolesAsync(user, rolesList.Select(x => x.Name).ToArray());
        _hmsDbContext.Users.Update(user);
        await _hmsDbContext.SaveChangesAsync();
    }
}
