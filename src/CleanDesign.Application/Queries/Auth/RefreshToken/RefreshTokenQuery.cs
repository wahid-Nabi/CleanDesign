using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.Auth.RefreshToken
{
    public class RefreshTokenQuery : IRequest<Result<TokenViewModel>>
    {
        public required string RefreshToken { get; set; }
        public required string BearerToken { get; set; }
    }
}
