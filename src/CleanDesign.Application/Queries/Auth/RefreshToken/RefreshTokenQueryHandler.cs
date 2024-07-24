using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.Auth.RefreshToken
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, Result<TokenViewModel>>
    {
        private readonly IAuthRepository _authRepository;
        public RefreshTokenQueryHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<Result<TokenViewModel>> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            TokenViewModel refreshTokenModel = new(request.BearerToken, request.RefreshToken);
            return await _authRepository.RefreshTokenAsync(refreshTokenModel);
        }
    }
}
