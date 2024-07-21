using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;

namespace CleanDesign.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<Result<TokenViewModel>> LoginAsync(LoginViewModel model);
        Task<Result<bool>> RegisterAsync(RegisterViewModel model);
    }
}
