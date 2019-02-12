using System;
using Sport.Services.Dto;

namespace Sport.Services.Interfaces
{
    public interface IJwtService
    {
        JwtDto CreateToken(Guid userId, RoleDto role);
    }
}