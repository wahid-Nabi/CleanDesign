using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;

namespace CleanDesign.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<Result> LoginAsync(LoginViewModel model);
        Task<Result<TokenViewModel>> RefreshTokenAsync(TokenViewModel refreshTokenModel);
        Task<Result> RegisterAsync(RegisterViewModel model);
        Task<Result> ForgetPasswordAsync(string email);
        Task<Result> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<Result> ConfirmEmailAsync(ConfirmEmailViewModel model);
        Task<Result<TokenViewModel>> ValidateTwoFactorTokenAsync(ValidateTwoFactorTokenViewModel model);
    }
}
