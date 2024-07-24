
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.Auth.ValidateToken
{
    public class ValidateTwoFactorTokenQueryHandler : IRequestHandler<ValidateTwoFactorTokenQuery, Result<TokenViewModel>>
    {
        private readonly IAuthRepository _authRepository;

        public ValidateTwoFactorTokenQueryHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Result<TokenViewModel>> Handle(ValidateTwoFactorTokenQuery request, CancellationToken cancellationToken)
        {
            var validateTwoFactorToken = new ValidateTwoFactorTokenViewModel()
            {

                OTP = request.OTP,
                Email = request.Email,
            };
            return await _authRepository.ValidateTwoFactorTokenAsync(validateTwoFactorToken);


        }
    }
}
