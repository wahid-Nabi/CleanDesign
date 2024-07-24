
using AutoMapper;
using CleanDesign.Application.Commands.Auth.ConfirmPassword;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Auth.ConfirmationEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        public ConfirmEmailCommandHandler(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmViewModel = _mapper.Map<ConfirmEmailViewModel>(request);
            var response = _authRepository.ConfirmEmailAsync(confirmViewModel);
            return response;
        }
    }
}
