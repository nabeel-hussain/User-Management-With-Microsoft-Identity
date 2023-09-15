using UM.Domain.Entities;
using UM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UM.Domain.Constants;
using UM.Domain.SlimEntities;
using System.Reflection.Metadata;
using UM.Domain.Interfaces.Authentication;
using UM.Domain.Interfaces;

namespace UM.Application.Security.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        readonly IUser _userRepository;
        readonly IJwtTokenManager _jwtManager;
        readonly IRole _roleRepository;
        public LoginCommandHandler(IUser userRepository, IJwtTokenManager jwtManager, IRole roleRepository)
        {
            _userRepository = userRepository;
            _jwtManager = jwtManager;
            _roleRepository = roleRepository;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null)
                throw new LoginFailedException(ValidationMessages.User.LoginFailed);
            
            var signInResult = await _userRepository.CheckPasswordSignIn(user,request.Password);
            if (!signInResult.Succeeded)
                throw new LoginFailedException(ValidationMessages.User.LoginFailed);
            var rolesNames = await _userRepository.GetUserRoles(user);
            var roles = (await  _roleRepository.GetAllRoles()).Where(x => rolesNames.Contains(x.Name)).ToList();
            var accessToken = await _jwtManager.GenerateToken(user,roles);
            var slimUser = new SlimUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                EmailAddress = user.Email,
                Roles = rolesNames,
                HotelId = Guid.NewGuid(),
                IsLocked = false
            };
            return new LoginCommandResponse(slimUser,accessToken);
            
        }
    }
}
