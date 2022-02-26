using Quiztime.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Interfaces
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> GenerateToken(AppUser user, IList<string> roles);
    }
}
