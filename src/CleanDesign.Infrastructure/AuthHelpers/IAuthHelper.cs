using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;

namespace CleanDesign.Infrastructure.AuthHelpers
{
    public interface IAuthHelper
    {
        Task<TokenViewModel> GenerateAuthTokens(ApplicationUser user);
    }
}
