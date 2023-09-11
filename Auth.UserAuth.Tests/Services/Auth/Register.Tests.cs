using Auth.UserAuth.Models.Entities;
using Common.Models.Helper;
using Common.Models.Helper.ResultTypes;
using NSubstitute;

namespace Auth.UserAuth.Tests.Services.Auth
{
    public class Register: Base
    {
        public Register(): base() { 
            
        }

        [Fact]
        public async Task IfCreateUserFails_ShouldNotContinue()
        {
            _dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 8, 18, 20, 01, 00, TimeSpan.Zero));
            var registrationForm = new RegistrationForm("gsphere", "", "", "gsphere@example.com", _dateTimeProvider.Now.AddYears(-28));

            _userService.CreateUser(registrationForm).Returns(ResultHelper.BadRequest<User>());
            
            var result = await _sut.Register(registrationForm);

            Assert.IsType<BadRequest<IdentityToken>>(result);
            await _userService.DidNotReceiveWithAnyArgs().AssignBaseRoles(new User());
        }
    }
}
