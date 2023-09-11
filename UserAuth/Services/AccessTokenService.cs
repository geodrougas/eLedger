using Auth.UserAuth.Interfaces.Services;
using Auth.UserAuth.Models.Entities;
using Common.Models.Helper.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Services
{
    public record AccessTokenService : IAccessTokenService
    {
        public Task<string> CreateJwt(AccessToken accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult<AccessToken>> GenerateAccessToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
