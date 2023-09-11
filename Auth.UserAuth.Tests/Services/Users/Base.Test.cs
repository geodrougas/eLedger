using Auth.UserAuth.Interfaces.Repositories;
using Auth.UserAuth.Interfaces.Tools;
using Auth.UserAuth.Models.Entities;
using Auth.UserAuth.Services;
using Common.Interfaces.Tools;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using NSubstitute;
namespace Auth.UserAuth.Tests.Services.Users
{
    public class Base
    {
        protected UserService _sut;
        protected IUserManager _userManager = Substitute.For<IUserManager>();
        protected IStringLocalizer<UserService> stringLocalizer = Substitute.For<IStringLocalizer<UserService>>();
        protected IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        protected IUserServiceRepository _userServiceRepository = Substitute.For<IUserServiceRepository>();
        protected IValidator<RegistrationForm> _validator = Substitute.For<IValidator<RegistrationForm>>();
        public Base()
        {
            _sut = new(_userManager, _dateTimeProvider, _userServiceRepository, stringLocalizer, _validator);
        }
    }
}
