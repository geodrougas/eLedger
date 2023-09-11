using Auth.UserAuth.Models.Entities;
using Common.Interfaces.Tools;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auth.UserAuth.Validators
{
    public class RegistrationFormValidator: AbstractValidator<RegistrationForm>
    {
        private static readonly char[] SYMBOLS = Enumerable.Range(33, 15).Select(it => (char)it).ToArray();
        private static readonly char[] LOWER_CHARACTERS = Enumerable.Range(97, 16).Select(it => (char)it).ToArray();
        private static readonly char[] UPPER_CHARACTERS = Enumerable.Range(65, 16).Select(it => (char)it).ToArray();
        private static readonly char[] NUMBERS = Enumerable.Range(48, 10).Select(it => (char)it).ToArray();

        public RegistrationFormValidator(StringLocalizer<RegistrationFormValidator> stringLocalizer, IDateTimeProvider dateTimeProvider) {
            RuleFor(rf => rf.UserName).Length(3,15).WithErrorCode("Username-Length").WithMessage(stringLocalizer["UsernameLength"]);
            RuleFor(rf => rf.Password).Equal(p => p.RepeatPassword).WithErrorCode("Password-Missmatch").WithMessage(stringLocalizer["PasswordMissmatch"]);
            RuleFor(rf => rf.Password).Length(8, 50).WithErrorCode("Password-Length").WithMessage(stringLocalizer["PasswordLength"]);
            RuleFor(rf => rf.Password).Must(p => p.Any(c => SYMBOLS.Contains(c))).WithErrorCode("Password-NoSymbols").WithMessage(stringLocalizer["PasswordNoSymbols"]);
            RuleFor(rf => rf.Password).Must(p => p.Any(c => LOWER_CHARACTERS.Contains(c))).WithErrorCode("Password-NoLower").WithMessage(stringLocalizer["PasswordNoLower"]);
            RuleFor(rf => rf.Password).Must(p => p.Any(c => UPPER_CHARACTERS.Contains(c))).WithErrorCode("Password-NoUpper").WithMessage(stringLocalizer["PasswordNoUpper"]);
            RuleFor(rf => rf.Password).Must(p => p.Any(c => NUMBERS.Contains(c))).WithErrorCode("Password-NoNumbers").WithMessage(stringLocalizer["PasswordNoNumbers"]);
            RuleFor(rf => rf.Email).EmailAddress().WithErrorCode("Email-Invalid").WithMessage(stringLocalizer["InvalidEmail"]);
        }
    }
}
