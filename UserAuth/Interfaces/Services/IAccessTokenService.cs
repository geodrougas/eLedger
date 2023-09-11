using Auth.UserAuth.Models.Entities;
using Common.Models.Helper.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Interfaces.Services
{
    public interface IAccessTokenService
    {
        Task<string> CreateJwt(AccessToken accessToken);
        Task<ObjectResult<AccessToken>> GenerateAccessToken(User user);
    }
}
