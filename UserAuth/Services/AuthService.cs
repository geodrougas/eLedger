using Auth.UserAuth.Interfaces.Repositories;
using Auth.UserAuth.Interfaces.Services;
using Auth.UserAuth.Models.Aggregates;
using Auth.UserAuth.Models.Entities;
using Common.Models.Helper;
using Common.Models.Helper.ResultTypes;
using Common.Models.ValueTypes;
using Microsoft.Extensions.Localization;

namespace Auth.UserAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserService _userService;
        private readonly IStringLocalizer<AuthService> _stringLocalizer;
        private readonly IUserServiceRepository _userServiceRepository;
        public AuthService(
            IAccessTokenService accessTokenService,
            IRefreshTokenService refreshTokenService,
            IUserService userService,
            IStringLocalizer<AuthService> stringLocalizer,
            IUserServiceRepository userServiceRepository)
        {
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
            _userService = userService;
            _stringLocalizer = stringLocalizer;
            _userServiceRepository = userServiceRepository;
        }

        public async Task<ObjectResult<AuthenticationUnit>> Login(LoginInfo loginInfo)
        {
            var unitOfWork = _userServiceRepository.StartTransaction();
            try { 
                ObjectResult<User>? userResult = await _userService.GetUser(loginInfo.UserName);

                User? user = userResult;
                if (user == null)
                    return userResult.Convert();

                var authenticationResult = await _userService.Authenticate(user, loginInfo.Password);

                if (authenticationResult.IsFailure)
                    return authenticationResult.Convert();

                var result = await GenerateAuthenticationUnit(user, loginInfo.RememberMe);

                await unitOfWork.SaveAsync();

                return result;
            } finally
            {
                unitOfWork.EndTransaction();
            }
        }

        public async Task<ObjectResult<IdentityToken>> Register(RegistrationForm registrationForm)
        {
            var unitOfWork = _userServiceRepository.StartTransaction();

            try
            {
                ObjectResult<User> userResult = await _userService.CreateUser(registrationForm);

                User? user = userResult;

                if (user == null)
                    return userResult.Convert();

                ObjectResult<Unit> unitResult = await _userService.AssignBaseRoles(user);

                if (unitResult.IsFailure)
                    return unitResult.Convert();

                ObjectResult<IdentityToken> identityTokenResult = await _userService.GenerateIdentityToken(user);

                await unitOfWork.SaveAsync();

                return identityTokenResult;
            }
            finally
            {
                unitOfWork.EndTransaction();
            }
        }

        public async Task<ObjectResult<AuthenticationUnit>> RenewToken(string refreshTokenStr)
        {
            var unitOfWork = _userServiceRepository.StartTransaction();
            try {
                ObjectResult<RefreshToken> refreshTokenResult = await _refreshTokenService.Validate(refreshTokenStr);

                RefreshToken? refreshToken = refreshTokenResult;

                if (refreshToken == null)
                    return refreshTokenResult.Convert();

                ObjectResult<User> userResult = await GetUser(refreshToken);

                User? user = userResult;
                if (user == null)
                    return userResult.Convert();

                ObjectResult<AuthenticationUnit> authenticationResult = await GenerateAuthenticationUnit(user, true);

                await unitOfWork.SaveAsync();

                return authenticationResult;
            }
            finally
            {
                unitOfWork.EndTransaction();
            }
        }

        #region private
        private async Task<ObjectResult<string>> GenerateRefreshToken(User user)
        {
            var refreshTokenResult = await _refreshTokenService.GenerateRefreshToken(user);

            RefreshToken? refreshToken = refreshTokenResult;
            if (refreshToken == null)
                return refreshTokenResult.Convert();

            return await _refreshTokenService.CreateJwt(refreshToken);
        }

        private async Task<ObjectResult<string>> GenerateAccessToken(User user)
        {
            var accessTokenResult = await _accessTokenService.GenerateAccessToken(user);

            AccessToken? accessToken = accessTokenResult;

            if (accessToken == null)
                return accessTokenResult.Convert();

            return await _accessTokenService.CreateJwt(accessToken);
        }

        private async Task<ObjectResult<User>> GetUser(RefreshToken validatedRefreshToken)
        {
            string username = await _refreshTokenService.GetUserName(validatedRefreshToken);

            var userResult = await _userService.GetUser(username);

            User? user = userResult;
            if (user == null)
                return userResult.Convert();

            return user;
        }

        private async Task<ObjectResult<AuthenticationUnit>> GenerateAuthenticationUnit(User user, bool rememberMe)
        {
            var identityTokenResult = await _userService.GenerateIdentityToken(user);

            IdentityToken? identityToken = identityTokenResult;
            if (identityToken == null)
                return identityTokenResult.Convert();

            var accessTokenResult = await GenerateAccessToken(user);

            string? accessToken = accessTokenResult;

            if (accessToken == null)
                return accessTokenResult.Convert();

            string? refreshToken = null;
            if (rememberMe)
            {
                var refreshTokenResult = await GenerateRefreshToken(user);

                refreshToken = refreshTokenResult;
                if (refreshToken == null)
                    return refreshTokenResult.Convert();
            }

            return new AuthenticationUnit(refreshToken, accessToken, identityToken);
        }
        #endregion private
    }
}
