using Auth.UserAuth.Interfaces.Repositories;
using Auth.UserAuth.Interfaces.Services;
using Auth.UserAuth.Services;
using Common.Interfaces.Tools;
using Microsoft.Extensions.Localization;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Tests.Services.Auth
{
    public class Base
    {
        protected AuthService _sut;
        protected IAccessTokenService _accessTokenService = Substitute.For<IAccessTokenService>();
        protected IRefreshTokenService _refreshTokenService = Substitute.For<IRefreshTokenService>();
        protected IUserService _userService = Substitute.For<IUserService>();
        protected IStringLocalizer<AuthService> stringLocalizer = Substitute.For<IStringLocalizer<AuthService>>();
        protected IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        protected IUserServiceRepository _userServiceRepository = Substitute.For<IUserServiceRepository>();

        public Base()
        {
            _sut = new(_accessTokenService, _refreshTokenService, _userService, stringLocalizer, _userServiceRepository);
        }
    }
}
