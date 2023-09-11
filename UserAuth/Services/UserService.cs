using Auth.Base.Models.Entities.Criteria;
using Auth.UserAuth.Interfaces.Repositories;
using Auth.UserAuth.Interfaces.Services;
using Auth.UserAuth.Interfaces.Tools;
using Auth.UserAuth.Models.Entities;
using Auth.UserAuth.Validators;
using Common.Interfaces.Tools;
using Common.Models.Helper;
using Common.Models.Helper.ResultTypes;
using Common.Models.ValueTypes;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Collections.Immutable;

namespace Auth.UserAuth.Services
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserServiceRepository _userRepository;
        private readonly IStringLocalizer<UserService> _stringLocalizer;
        private readonly IValidator<RegistrationForm> _registrationFormValidator;

        public UserService(
            IUserManager userManager,
            IDateTimeProvider dateTimeProvider,
            IUserServiceRepository userRepository,
            IStringLocalizer<UserService> stringLocalizer,
            IValidator<RegistrationForm> registrationFormValidator)
        {
            _userManager = userManager;
            _dateTimeProvider = dateTimeProvider;
            _userRepository = userRepository;
            _stringLocalizer = stringLocalizer;
            _registrationFormValidator = registrationFormValidator;
        }

        public async Task<ObjectResult<Unit>> AssignBaseRoles(User user)
        {
            var unitOfWork = _userRepository.StartTransaction();

            try { 
                var baseRoles = await _userRepository.GetRoles(new RoleCriteria( IsBase: true ));

                foreach (var role in baseRoles)
                {
                    user.Roles.Add(role);
                }

                await unitOfWork.SaveAsync();

                return ResultHelper.NoContent<Unit>();
            } 
            finally
            {
                unitOfWork.EndTransaction();
            }
        }

        public async Task<ObjectResult<Unit>> Authenticate(User user, string password)
        {
            var success = await _userManager.CheckPasswordAsync(user, password);

            if (success)
                return new NoContent<Unit>();
            else 
                return new NotAuthorized<Unit>(
                    _stringLocalizer["InvalidPassword"]);
        }

        public async Task<ObjectResult<User>> CreateUser(RegistrationForm registrationForm)
        {
            var unitOfWork = _userRepository.StartTransaction();
            try { 
                var validationResult = await _registrationFormValidator.ValidateAsync(registrationForm);
            
                if (!validationResult.IsValid)
                    return new BadRequest<User>(ValidatorHelper.WrapErrors(validationResult));

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = registrationForm.UserName,
                    NormalizedUserName = registrationForm.UserName.ToLower(),
                    Email = registrationForm.Email,
                    NormalizedEmail = registrationForm.Email.ToLower(),
                    LockoutEnabled = true
                };

                await ChangePassword(user, null, registrationForm.Password);

                user.ConcurrencyStamp = await _userManager.GenerateConcurrencyStampAsync(user);

                _userRepository.Add(user);

                await unitOfWork.SaveAsync();

                return ResultHelper.Ok(user);
            }
            finally
            {
                unitOfWork.EndTransaction();
            }
        }

        public async Task<ObjectResult<IdentityToken>> GenerateIdentityToken(User user)
        {
            return new IdentityToken(
                user.UserName!,
                user.Email!,
                user.EmailConfirmed,
                user.Roles.Select(m => m.NormalizedName!).ToList()
            );
        }

        public async Task<ObjectResult<User>> GetUser(string username)
        {
            User? user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return ResultHelper.NotFound<User>(_stringLocalizer["The user {0} was not found.", username]);

            return user;
        }

        public async Task<ObjectResult<User>> ChangePassword(User user, string? currentPassword, string password)
        {
            var unitOfWork = _userRepository.StartTransaction();
            try { 
                var identityResult = await _userManager.ChangePasswordAsync(user, currentPassword, password);
    
                
                if (!identityResult.Succeeded) {
                    return ResultHelper.BadRequest<User>(identityResult.Errors.First().Description);
                }

                user.ConcurrencyStamp = await _userManager.GenerateConcurrencyStampAsync(user);
                user.SecurityStamp = await _userManager.GetSecurityStampAsync(user);

                await unitOfWork.SaveAsync();

                return new Ok<User>(user);
            } finally
            {
                unitOfWork.EndTransaction();
            }
        }
    }
}
