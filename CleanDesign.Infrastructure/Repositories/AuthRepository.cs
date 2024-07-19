using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Errors;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace CleanDesign.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<string>> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new(string.Empty, false, LoginErrors.UserNotFound);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (!result.Succeeded)
            {
                return new(string.Empty, false, LoginErrors.InvalidCredentials);
            }
            return new("Login Success", true, Error.None);

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
                return new(false, false, UserRegisterErrors.RegistrationFailed);
            }
            return new(true, true, Error.None);
            
        }
    }
}
