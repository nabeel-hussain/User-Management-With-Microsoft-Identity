using UM.Domain.Constants;
using UM.Domain.Entities;
using UM.Domain.Interfaces;
using UM.Domain.Interfaces.Authentication;
using UM.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UM.Infrastructure.Authentication;

public class JwtTokenManager : IJwtTokenManager
{
    public readonly JwtOptions _jwtOptions;
    public readonly IRole _roleRepository;
    public JwtTokenManager(IOptions<JwtOptions> jwtOptions, IRole roleRepository)
    {
        _jwtOptions = jwtOptions.Value;
        _roleRepository = roleRepository;
    }

    public async Task<string> GenerateToken(User user, List<Role> roles)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(CustomClaimTypes.UserId, user.Id.ToString())
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(CustomClaimTypes.Role, role.Name));
            var roleClaims = await _roleRepository.GetRoleClaims(role);
            claims.AddRange(roleClaims.Where(x => x.Type == CustomClaimTypes.Permissions));
        }
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
