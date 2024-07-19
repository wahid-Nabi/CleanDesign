using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;

namespace CleanDesign.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<Result<string>> LoginAsync(LoginViewModel model);
        Task<Result<bool>> RegisterAsync(RegisterViewModel model);
    }
}
