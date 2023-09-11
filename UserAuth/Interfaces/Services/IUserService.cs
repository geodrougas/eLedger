using Auth.Base.Models;
using Auth.UserAuth.Models.Entities;
using Common.Models.Helper.ResultTypes;
using Common.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Interfaces.Services
{
    public interface IUserService
    {
        Task<ObjectResult<Unit>> AssignBaseRoles(User user);
        Task<ObjectResult<Unit>> Authenticate(User user, string password);
        Task<ObjectResult<User>> CreateUser(RegistrationForm registrationForm);
        Task<ObjectResult<IdentityToken>> GenerateIdentityToken(User user);
        public Task<ObjectResult<User>> GetUser(string username);
    }
}
