using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sport.Services.Dto;
using Sport.Services.Interfaces;
using Sport.Services.Settings;

namespace Sport.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtSettings> _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public JwtDto CreateToken(Guid userId, RoleDto role)
        {
            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret)),
                    SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
                    {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                    };

            var token = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new JwtDto
            {
                Token = tokenString
            };
        }
    }
}