using Auth.UserAuth.Models.Entities;
using Common.Models.Helper.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Interfaces.Services
{
    public interface IRefreshTokenService
    {
        Task<ObjectResult<string>> CreateJwt(RefreshToken item);
        Task<ObjectResult<RefreshToken>> GenerateRefreshToken(User user);
        Task<string> GetUserName(RefreshToken body);
        Task<ObjectResult<RefreshToken>> Validate(string refreshTokenStr);
    }
}
