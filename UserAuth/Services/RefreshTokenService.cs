using Auth.Base.Models;
using Auth.UserAuth.Interfaces.Services;
using Auth.UserAuth.Models;
using Auth.UserAuth.Models.Entities;
using Auth.UserAuth.Models.Entities.Options;
using Common.Interfaces.Tools;
using Common.Models.Helper.ResultTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly RefreshTokenOptions _refreshTokenOptions;

        public RefreshTokenService(IDateTimeProvider dateTimeProvider, RefreshTokenOptions refreshTokenOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _refreshTokenOptions = refreshTokenOptions;
        }

        public Task<ObjectResult<string>> CreateJwt(RefreshToken item)
        {
            throw new NotImplementedException();
        }

        public async Task<ObjectResult<RefreshToken>> GenerateRefreshToken(User user)
        {
            return RefreshToken.GenerateToken(_dateTimeProvider, _refreshTokenOptions.LifetimeDuration, user, application, ipAddress);
        }

        public Task<string> GetUserName(RefreshToken body)
        {
            return Task.FromResult(body.UserName);
        }

        public Task<ObjectResult<RefreshToken>> Validate(string refreshTokenStr)
        {
            throw new NotImplementedException();
        }
    }
}
