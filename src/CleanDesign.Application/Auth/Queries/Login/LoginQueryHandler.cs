using MediatR;
using CleanDesign.SharedKernel;
using AutoMapper;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.Application.Exceptions;

namespace CleanDesign.Application.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<TokenViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        public LoginQueryHandler(IMapper mapper, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }
        public async Task<Result<TokenViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            EmailNullException.ThrowIfNull(request.Email);

            var loginVM = _mapper.Map<LoginViewModel>(request);
            var result = await _authRepository.LoginAsync(loginVM);
            return result;

        }
    }
}
