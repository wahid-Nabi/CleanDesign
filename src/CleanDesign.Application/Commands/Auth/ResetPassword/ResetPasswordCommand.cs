using CleanDesign.SharedKernel;
using CleanDesign.SharedKernel.Enums;
using MediatR;

namespace CleanDesign.Application.Commands.Auth.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Result>
    {
        public string? Email { get; set; }
        public string? OTP { get; set; }
        public required string NewPassword { get; set; }
        public string? OldPassword { get; set; }
        public ResetPasswordMethod ResetPasswordMethod { get; set; }
    }
}
