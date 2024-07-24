using CleanDesign.Application.Abstractions;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Errors;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Infrastructure.AuthHelpers;
using CleanDesign.Infrastructure.Exceptions;
using CleanDesign.SharedKernel;
using CleanDesign.SharedKernel.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CleanDesign.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthHelper _authHelper;
        private readonly AuthSettings _authSettings;
        private readonly AppSettings _appSettings;
        private readonly IEmailSender _emailSender;
        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthHelper authHelper, IOptions<AppSettings> appSetting, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authHelper = authHelper;
            _authSettings = appSetting.Value.AuthSettings;
            _emailSender = emailSender;
            _appSettings = appSetting.Value;
        }

        public async Task<Result> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);


            if (user == null)
            {
                return Result.Failure<TokenViewModel>(GenericAuthErrors.InvalidEmail);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return Result.Failure<TokenViewModel>(GenericAuthErrors.EmailNotConfirmed);
            };

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (!result.Succeeded)
            {
                return Result.Failure<TokenViewModel>(LoginErrors.InvalidCredentials);
            }

            return await SendTwoFactorTokenAsync(user);
        }

        public async Task<Result> RegisterAsync(RegisterViewModel model)
        {
            var userId = Guid.NewGuid();
            var user = new ApplicationUser()
            {
                Name = model.Name,
                UserName = model.UserName,
                NormalizedUserName = model.UserName.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                PhoneNumber = model.PhoneNumber,
                CreatedOn = DateTime.Now,
                CreatedBy = userId,
                UpdatedBy = userId,
                UpdatedOn = DateTime.Now
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Result.Failure<bool>(UserRegisterErrors.RegistrationFailed);
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string subject = "CleanDesign - Confirmation email";
            string link = _appSettings.BaseUiUrl + $"/confirm-email/{user.UserName}/{token}";
            string body = $"<p>Confirm the email, Please click link <a href='{link}'>{link}</a></p>";
            var mailModel = new EmailViewModel(user.Email, subject, body);
            return _emailSender.SendEmail(mailModel);
        }

        public async Task<Result<TokenViewModel>> RefreshTokenAsync(TokenViewModel model)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(model.RefreshToken));
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(model.BearerToken));

            var claims = _authHelper.GetPrincipalFromExpiredToken(model.BearerToken);
            var userName = claims?.Identity?.Name;

            ApplicationUser? user = await _userManager.FindByNameAsync(userName ?? "");
            bool result = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, _authSettings.RefreshTokenPurpose, model.RefreshToken);

            if (!result)
            {
                throw new SecurityTokenValidationException();
            }

            TokenViewModel tokens = await _authHelper.GenerateAuthTokensAsync(user);
            return Result.Success(tokens);
        }

        public async Task<Result> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new EmailNotRegisteredException();
            }
            //var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
            //string subject = "OTP for recent password is sent";
            //string body = $"Reset Password OTP: {code}";
            var result = await SendTwoFactorTokenAsync(user);
            return result;
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordViewModel model)
        {

            ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email ?? "");
            if (user == null)
            {
                throw new EmailNotRegisteredException();
            }

            IdentityResult identityResult;
            if (model.ResetPasswordMethod == ResetPasswordMethod.ForgetPassword)
            {
                bool isOtpValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider, model.OTP);
                if (!isOtpValid)
                    return Result.Failure(GenericAuthErrors.InvalidToken);

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
                identityResult = await _userManager.UpdateAsync(user);
            }
            else
            {
                identityResult = await _userManager.ChangePasswordAsync(user, model.OldPassword ?? "", model.NewPassword);
            }
            if (!identityResult.Succeeded)
            {
                return Result.Failure(GenericAuthErrors.PasswordResetFailed);
            }

            return Result.Success();
        }

        public async Task<Result> ConfirmEmailAsync(ConfirmEmailViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Result.Failure(LoginErrors.UserNotFound);
            }

            var result = await _userManager.ConfirmEmailAsync(user, model.Token);
            if (!result.Succeeded)
            {
                return Result.Failure(GenericAuthErrors.EmailConfirmationFailed);
            }
            return Result.Success();
        }

        private async Task<Result> SendTwoFactorTokenAsync(ApplicationUser user)
        {
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
            string subject = "CleanDesign - Two factor verification";
            string body = $"Two Factor OTP: {code}";

            var model = new EmailViewModel(user?.Email ?? string.Empty, subject, body);
            return _emailSender.SendEmail(model);
        }

        public async Task<Result<TokenViewModel>> ValidateTwoFactorTokenAsync(ValidateTwoFactorTokenViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) {
                return Result.Failure<TokenViewModel>(LoginErrors.UserNotFound);
            }

            var response = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider, model.OTP);
            if (!response)
            {
                return Result.Failure<TokenViewModel>(GenericAuthErrors.InvalidToken);
            }
            TokenViewModel tokens = await _authHelper.GenerateAuthTokensAsync(user);
            return Result.Success(tokens);
        }
    }
}
