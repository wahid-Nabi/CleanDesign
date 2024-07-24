
using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.Auth.ValidateToken
{
    public class ValidateTwoFactorTokenQuery : IRequest<Result<TokenViewModel>>
    {
        public required string  OTP { get; set; }
        public required string Email { get; set; }      
    }
}
