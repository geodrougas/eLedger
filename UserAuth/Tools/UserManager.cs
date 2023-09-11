using Auth.UserAuth.Interfaces.Tools;
using Auth.UserAuth.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Tools
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<User> _userManager;
        public UserManager(UserManager<User> userManager) { 
            this._userManager = userManager;
        }

        public IdentityErrorDescriber ErrorDescriber { get => _userManager.ErrorDescriber; set { _userManager.ErrorDescriber = value; } }
        public ILookupNormalizer KeyNormalizer { get => _userManager.KeyNormalizer; set { _userManager.KeyNormalizer = value; } }
        public ILogger Logger { get => _userManager.Logger; set { _userManager.Logger = value; } }
        public IdentityOptions Options { get => _userManager.Options; set { _userManager.Options = value; } }
        public IPasswordHasher<User> PasswordHasher { get => _userManager.PasswordHasher; set { _userManager.PasswordHasher = value; } }

        public IList<IPasswordValidator<User>> PasswordValidators => _userManager.PasswordValidators;

        public bool SupportsQueryableUsers => _userManager.SupportsQueryableUsers;

        public bool SupportsUserAuthenticationTokens => _userManager.SupportsUserAuthenticationTokens;

        public bool SupportsUserAuthenticatorKey => _userManager.SupportsUserAuthenticatorKey;

        public bool SupportsUserClaim => _userManager.SupportsUserClaim;

        public bool SupportsUserEmail => _userManager.SupportsUserEmail;

        public bool SupportsUserLockout => _userManager.SupportsUserLockout;

        public bool SupportsUserLogin => _userManager.SupportsUserLogin;

        public bool SupportsUserPassword => _userManager.SupportsUserPassword;

        public bool SupportsUserPhoneNumber => _userManager.SupportsUserPhoneNumber;

        public bool SupportsUserRole => _userManager.SupportsUserRole;

        public bool SupportsUserSecurityStamp => _userManager.SupportsUserSecurityStamp;

        public bool SupportsUserTwoFactor => _userManager.SupportsUserTwoFactor;

        public bool SupportsUserTwoFactorRecoveryCodes => _userManager.SupportsUserTwoFactorRecoveryCodes;

        public IQueryable<User> Users => _userManager.Users;

        public IList<IUserValidator<User>> UserValidators => _userManager.UserValidators;

        public Task<IdentityResult> AccessFailedAsync(User user)
        {
            return _userManager.AccessFailedAsync(user);
        }

        public Task<IdentityResult> AddClaimAsync(User user, Claim claim)
        {
            return _userManager.AddClaimAsync(user, claim);
        }

        public Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims)
        {
            return _userManager.AddClaimsAsync(user, claims);
        }

        public Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login)
        {
            return _userManager.AddLoginAsync(user, login);
        }

        public Task<IdentityResult> AddPasswordAsync(User user, string password)
        {
            return _userManager.AddPasswordAsync(user, password);
        }

        public Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }

        public Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
        {
            return _userManager.AddToRolesAsync(user, roles);
        }

        public Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
        {
            return _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public Task<IdentityResult> ChangePasswordAsync(User user, string? currentPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public Task<IdentityResult> ChangePhoneNumberAsync(User user, string phoneNumber, string token)
        {
            return _userManager.ChangePhoneNumberAsync(user, phoneNumber, token);
        }

        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }

        public Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return _userManager.ConfirmEmailAsync(user, token);
        }

        public Task<int> CountRecoveryCodesAsync(User user)
        {
            return _userManager.CountRecoveryCodesAsync(user);
        }

        public Task<IdentityResult> CreateAsync(User user)
        {
            return _userManager.CreateAsync(user);
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<byte[]> CreateSecurityTokenAsync(User user)
        {
            return _userManager.CreateSecurityTokenAsync(user);
        }

        public Task<IdentityResult> DeleteAsync(User user)
        {
            return _userManager.DeleteAsync(user);
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }

        public Task<User?> FindByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<User?> FindByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public Task<User?> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return _userManager.FindByLoginAsync(loginProvider, providerKey);
        }

        public Task<User?> FindByNameAsync(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public Task<string> GenerateChangeEmailTokenAsync(User user, string newEmail)
        {
            return _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        }

        public Task<string> GenerateChangePhoneNumberTokenAsync(User user, string phoneNumber)
        {
            return _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
        }

        public Task<string> GenerateConcurrencyStampAsync(User user)
        {
            return _userManager.GenerateConcurrencyStampAsync(user);
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public string GenerateNewAuthenticatorKey()
        {
            return _userManager.GenerateNewAuthenticatorKey();
        }

        public Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(User user, int number)
        {
            return _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        }

        public Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<string> GenerateTwoFactorTokenAsync(User user, string tokenProvider)
        {
            return _userManager.GenerateTwoFactorTokenAsync(user, tokenProvider);
        }

        public Task<string> GenerateUserTokenAsync(User user, string tokenProvider, string purpose)
        {
            return _userManager.GenerateUserTokenAsync(user, tokenProvider, purpose);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return _userManager.GetAccessFailedCountAsync(user);
        }

        public Task<string?> GetAuthenticationTokenAsync(User user, string loginProvider, string tokenName)
        {
            return _userManager.GetAuthenticationTokenAsync(user, loginProvider, tokenName);
        }

        public Task<string?> GetAuthenticatorKeyAsync(User user)
        {
            return _userManager.GetAuthenticatorKeyAsync(user);
        }

        public Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return _userManager.GetClaimsAsync(user);
        }

        public Task<string?> GetEmailAsync(User user)
        {
            return _userManager.GetEmailAsync(user);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return _userManager.GetLockoutEnabledAsync(user);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user)
        {
            return _userManager.GetLockoutEndDateAsync(user);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            return _userManager.GetLoginsAsync(user);
        }

        public Task<string?> GetPhoneNumberAsync(User user)
        {
            return _userManager.GetPhoneNumberAsync(user);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return _userManager.GetRolesAsync(user);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            return _userManager.GetSecurityStampAsync(user);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return _userManager.GetTwoFactorEnabledAsync(user);
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(User user)
        {
            return _userManager.GetValidTwoFactorProvidersAsync(user);
        }

        public Task<User?> GeUserAsync(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);
        }

        public string? GeUserId(ClaimsPrincipal principal)
        {
            return _userManager.GetUserId(principal);
        }

        public Task<string> GeUserIdAsync(User user)
        {
            return _userManager.GetUserIdAsync(user);
        }

        public string? GeUserName(ClaimsPrincipal principal)
        {
            return _userManager.GetUserName(principal);
        }

        public Task<string?> GeUserNameAsync(User user)
        {
            return _userManager.GetUserNameAsync(user);
        }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim)
        {
            return _userManager.GetUsersForClaimAsync(claim);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
            return _userManager.GetUsersInRoleAsync(roleName);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return _userManager.HasPasswordAsync(user);
        }

        public Task<bool> IsEmailConfirmedAsync(User user)
        {
            return _userManager.IsEmailConfirmedAsync(user);
        }

        public Task<bool> IsInRoleAsync(User user, string role)
        {
            return _userManager.IsInRoleAsync(user, role);
        }

        public Task<bool> IsLockedOutAsync(User user)
        {
            return _userManager.IsLockedOutAsync(user);
        }

        public Task<bool> IsPhoneNumberConfirmedAsync(User user)
        {
            return _userManager.IsPhoneNumberConfirmedAsync(user);
        }

        public string? NormalizeEmail(string? email)
        {
            return _userManager.NormalizeEmail(email);
        }

        public string? NormalizeName(string? name)
        {
            return _userManager.NormalizeName(name);
        }

        public Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(User user, string code)
        {
            return _userManager.RedeemTwoFactorRecoveryCodeAsync(user, code);
        }

        public void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<User> provider)
        {
            _userManager.RegisterTokenProvider(providerName, provider);
        }

        public Task<IdentityResult> RemoveAuthenticationTokenAsync(User user, string loginProvider, string tokenName)
        {
            return _userManager.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);
        }

        public Task<IdentityResult> RemoveClaimAsync(User user, Claim claim)
        {
            return _userManager.RemoveClaimAsync(user, claim);
        }

        public Task<IdentityResult> RemoveClaimsAsync(User user, IEnumerable<Claim> claims)
        {
            return _userManager.RemoveClaimsAsync(user, claims);
        }

        public Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
        {
            return _userManager.RemoveFromRoleAsync(user, role);
        }

        public Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
        {
            return _userManager.RemoveFromRolesAsync(user, roles);
        }

        public Task<IdentityResult> RemoveLoginAsync(User user, string loginProvider, string providerKey)
        {
            return _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
        }

        public Task<IdentityResult> RemovePasswordAsync(User user)
        {
            return _userManager.RemovePasswordAsync(user);
        }

        public Task<IdentityResult> ReplaceClaimAsync(User user, Claim claim, Claim newClaim)
        {
            return _userManager.ReplaceClaimAsync(user, claim, newClaim);
        }

        public Task<IdentityResult> ResetAccessFailedCountAsync(User user)
        {
            return _userManager.ResetAccessFailedCountAsync(user);
        }

        public Task<IdentityResult> ResetAuthenticatorKeyAsync(User user)
        {
            return _userManager.ResetAuthenticatorKeyAsync(user);
        }

        public Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            return _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public Task<IdentityResult> SetAuthenticationTokenAsync(User user, string loginProvider, string tokenName, string? tokenValue)
        {
            return _userManager.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);
        }

        public Task<IdentityResult> SetEmailAsync(User user, string? email)
        {
            return _userManager.SetEmailAsync(user, email);
        }

        public Task<IdentityResult> SetLockoutEnabledAsync(User user, bool enabled)
        {
            return _userManager.SetLockoutEnabledAsync(user, enabled);
        }

        public Task<IdentityResult> SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd)
        {
            return _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
        }

        public Task<IdentityResult> SetPhoneNumberAsync(User user, string? phoneNumber)
        {
            return _userManager.SetPhoneNumberAsync(user, phoneNumber);
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return _userManager.SetTwoFactorEnabledAsync(user, enabled);
        }

        public Task<IdentityResult> SetUserNameAsync(User user, string? userName)
        {
            return _userManager.SetUserNameAsync(user, userName);
        }

        public Task<IdentityResult> UpdateAsync(User user)
        {
            return _userManager.UpdateAsync(user);
        }

        public Task UpdateNormalizedEmailAsync(User user)
        {
            return _userManager.UpdateNormalizedEmailAsync(user);
        }

        public Task UpdateNormalizedUserNameAsync(User user)
        {
            return _userManager.UpdateNormalizedUserNameAsync(user);
        }

        public Task<IdentityResult> UpdateSecurityStampAsync(User user)
        {
            return _userManager.UpdateSecurityStampAsync(user);
        }

        public Task<bool> VerifyChangePhoneNumberTokenAsync(User user, string token, string phoneNumber)
        {
            return _userManager.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(User user, string tokenProvider, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        }

        public Task<bool> VerifyUserTokenAsync(User user, string tokenProvider, string purpose, string token)
        {
            return _userManager.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
        }
    }
}
