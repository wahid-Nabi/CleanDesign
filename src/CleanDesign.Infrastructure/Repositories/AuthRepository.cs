using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Errors;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Infrastructure.AuthHelpers;
using CleanDesign.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace CleanDesign.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthHelper _authHelper;

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthHelper authHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authHelper = authHelper;
        }

        public async Task<Result<TokenViewModel>> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Result.Failure<TokenViewModel>(GenericAuthErrors.InvalidEmail);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (!result.Succeeded)
            {
                return Result.Failure<TokenViewModel>(LoginErrors.InvalidCredentials);
            }

            TokenViewModel tokens = await _authHelper.GenerateAuthTokens(user);
            return Result.Success(tokens);
        }

        public async Task<Result<bool>> RegisterAsync(RegisterViewModel model)
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

            IdentityResult result = await _userManager.CreateAsync(user,model.Password);
            
            if (!result.Succeeded)
            {
                return Result.Failure<bool>(UserRegisterErrors.RegistrationFailed);
            }
            return Result.Success(true);
            
        }
    }
}
