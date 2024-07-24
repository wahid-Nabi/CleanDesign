using AutoMapper;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Auth.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public ResetPasswordCommandHandler(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var resetPasswordViewModel = _mapper.Map<ResetPasswordViewModel>(request);
            var response = _authRepository.ResetPasswordAsync(resetPasswordViewModel);
            return response;
        }
    }
}
