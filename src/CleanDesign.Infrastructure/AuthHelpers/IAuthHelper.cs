using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.SharedKernel;
using System.Security.Claims;

namespace CleanDesign.Infrastructure.AuthHelpers
{
    public interface IAuthHelper
    {
        Task<TokenViewModel> GenerateAuthTokensAsync(ApplicationUser user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string bearerToken);
        
    }
}
