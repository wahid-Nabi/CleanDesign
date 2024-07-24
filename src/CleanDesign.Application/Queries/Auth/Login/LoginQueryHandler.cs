using MediatR;
using CleanDesign.SharedKernel;
using AutoMapper;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Application.ViewModels;

namespace CleanDesign.Application.Queries.Auth.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result>
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        public LoginQueryHandler(IMapper mapper, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }
        public async Task<Result> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.Email);

            var loginVM = _mapper.Map<LoginViewModel>(request);
            var result = await _authRepository.LoginAsync(loginVM);
            return result;

        }
    }
}
