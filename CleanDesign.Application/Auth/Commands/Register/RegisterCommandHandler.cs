using AutoMapper;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;

        public RegisterCommandHandler(IMapper mapper, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _authRepository = authRepository;
        }

        public async Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerVM = _mapper.Map<RegisterViewModel>(request);
            var result = await _authRepository.RegisterAsync(registerVM);
            return result;
        }
    }
}
