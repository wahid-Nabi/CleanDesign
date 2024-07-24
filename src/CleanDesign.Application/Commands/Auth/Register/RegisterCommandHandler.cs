using AutoMapper;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Auth.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;

        public RegisterCommandHandler(IMapper mapper, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerVM = _mapper.Map<RegisterViewModel>(request);
            var result = await _authRepository.RegisterAsync(registerVM);
            return result;
        }
    }
}
