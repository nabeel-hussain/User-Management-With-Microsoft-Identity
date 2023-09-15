
using UM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace UM.Domain.Interfaces
{
    public interface IUser
    {
        public Task<User> GetUserById(Guid id);
        public Task<List<User>> GetAllUsers();
        public Task<List<string>> GetUserRoles(User user);
        public Task<User> GetUserByEmail(string email);
        public Task<List<User>> GetUsersByHotel(Guid hotelId);
        public Task AddUser(User user,string? password,List<string> roles);
        public Task UpdateUser(User user,List<string> roles);
        public Task DeleteUser(Guid id);
        public Task DeactivateUser(Guid id);
        public Task<IdentityResult> ChangePassword(User user,string oldPassword,string newPassword);
        public Task<SignInResult> CheckPasswordSignIn(User user,string password);

    }
}
