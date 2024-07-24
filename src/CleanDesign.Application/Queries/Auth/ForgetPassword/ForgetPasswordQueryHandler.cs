using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.Auth.ForgetPassword
{
    public class ForgetPasswordQueryHandler : IRequestHandler<ForgetPasswordQuery, Result>
    {
        private readonly IAuthRepository _authRepository;

        public ForgetPasswordQueryHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Result> Handle(ForgetPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _authRepository.ForgetPasswordAsync(request.Email);
        }

    }
}
