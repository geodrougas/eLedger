using Auth.UserAuth.Models.Aggregates;
using Auth.UserAuth.Models.Entities;
using Common.Interfaces.Tools;
using Common.Models.Helper;
using Common.Models.Helper.ResultTypes;
using Common.Models.ValueTypes;
using Microsoft.Extensions.Localization;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Tests.Services.Auth
{
    public class Login: Base
    {
        public Login(): base()
        {
        }

        [Fact]
        public async Task ShouldReturnAuthUnitWithRefreshToken_WhenUserExistsAndRememberIsTrue()
        {
            // Arrange
            LoginInfo loginInfo = new LoginInfo("George", "123455", "Mozilla", true);
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = loginInfo.UserName,
                Email = $"{loginInfo.UserName}@example.com"
            };
            var jwtToken = Guid.NewGuid().ToString();
            var refreshTokenStr = Guid.NewGuid().ToString();
            var identityToken = new IdentityToken(loginInfo.UserName, user.Email, true, false, new List<string>());

            _dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 8, 17, 10, 10, 10, TimeSpan.Zero));

            var accessToken = new AccessToken(Guid.NewGuid(), loginInfo.Application, new Timestamp(_dateTimeProvider.Now, user.Id), _dateTimeProvider.Now.AddHours(8));
            var refreshToken = new RefreshToken(Guid.NewGuid(), loginInfo.Application, new Timestamp(_dateTimeProvider.Now, user.Id), _dateTimeProvider.Now.AddMonths(1), false, false);

            _userService.GetUser(loginInfo.UserName).Returns(user);
            _userService.Authenticate(user, loginInfo.Password).Returns(ResultHelper.NoContent<Unit>());
            _userService.GenerateIdentityToken(user).Returns(identityToken);
            _accessTokenService.GenerateAccessToken(user).Returns(accessToken);
            _accessTokenService.CreateJwt(accessToken).Returns(jwtToken);
            _refreshTokenService.GenerateRefreshToken(user).Returns(refreshToken);
            _refreshTokenService.CreateJwt(refreshToken).Returns(refreshTokenStr);

            // Act
            var result = await _sut.Login(loginInfo);

            // Assert
            Assert.IsType<Ok<AuthenticationUnit>>(result);
            AuthenticationUnit? authenticationUnit = result;
            Assert.NotNull(authenticationUnit);
            Assert.NotNull(authenticationUnit.RefreshToken);
        }

        [Fact]
        public async Task ShouldReturnAuthUnitWithoutRefreshToken_WhenUserExistsAndRememberIsFalse()
        {
            // Arrange
            LoginInfo loginInfo = new LoginInfo("George", "123455", "Mozilla", false);
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = loginInfo.UserName,
                Email = $"{loginInfo.UserName}@example.com"
            };
            var jwtToken = Guid.NewGuid().ToString();
            var refreshTokenStr = Guid.NewGuid().ToString();
            var identityToken = new IdentityToken(loginInfo.UserName, user.Email, true, false, new List<string>());

            _dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 8, 17, 10, 10, 10, TimeSpan.Zero));

            var accessToken = new AccessToken(Guid.NewGuid(), loginInfo.Application, new Timestamp(_dateTimeProvider.Now, user.Id), _dateTimeProvider.Now.AddHours(8));
            var refreshToken = new RefreshToken(Guid.NewGuid(), loginInfo.Application, new Timestamp(_dateTimeProvider.Now, user.Id), _dateTimeProvider.Now.AddMonths(1), false, false);

            _userService.GetUser(loginInfo.UserName).Returns(user);
            _userService.Authenticate(user, loginInfo.Password).Returns(ResultHelper.NoContent<Unit>());
            _userService.GenerateIdentityToken(user).Returns(identityToken);
            _accessTokenService.GenerateAccessToken(user).Returns(accessToken);
            _accessTokenService.CreateJwt(accessToken).Returns(jwtToken);
            _refreshTokenService.GenerateRefreshToken(user).Returns(refreshToken);
            _refreshTokenService.CreateJwt(refreshToken).Returns(refreshTokenStr);

            // Act
            var result = await _sut.Login(loginInfo);

            // Assert
            Assert.IsType<Ok<AuthenticationUnit>>(result);
            AuthenticationUnit? authenticationUnit = result;
            Assert.NotNull(authenticationUnit);
            Assert.Null(authenticationUnit.RefreshToken);
        }

        [Fact]
        public async Task ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            LoginInfo loginInfo = new LoginInfo("George", "123455", "Mozilla", false);
            
            _userService.GetUser(loginInfo.UserName).Returns(ResultHelper.NotFound<User>());

            // Act
            var result = await _sut.Login(loginInfo);

            // Assert
            Assert.IsType<NotFound<AuthenticationUnit>>(result);
            await _userService.DidNotReceive().Authenticate(new User(), loginInfo.Password);
        }

        [Fact]
        public async Task ShouldReturnNotAuthorized_WhenUsersPasswordIsIncorrect()
        {
            // Arrange
            LoginInfo loginInfo = new LoginInfo("George", "123455", "Mozilla", false);
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = loginInfo.UserName,
                Email = $"{loginInfo.UserName}@example.com"
            };

            _userService.GetUser(loginInfo.UserName).Returns(user);
            _userService.Authenticate(user, loginInfo.Password).Returns(ResultHelper.NotAuthorized<Unit>("Wrong password"));

            // Act
            var result = await _sut.Login(loginInfo);

            // Assert
            Assert.IsType<NotAuthorized<AuthenticationUnit>>(result);
            await _userService.DidNotReceive().GenerateIdentityToken(user);
        }
    }
}
