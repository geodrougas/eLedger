using Auth.UserAuth.Models.Aggregates;
using Auth.UserAuth.Models.Entities;
using Common.Models.Helper.ResultTypes;

namespace Auth.UserAuth.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ObjectResult<AuthenticationUnit>> Login(LoginInfo loginInfo);
        Task<ObjectResult<IdentityToken>> Register(RegistrationForm registrationForm);
        Task<ObjectResult<AuthenticationUnit>> RenewToken(string refreshTokenStr);
    }
}