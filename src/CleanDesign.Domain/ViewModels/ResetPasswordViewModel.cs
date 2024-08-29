using CleanDesign.SharedKernel.Enums;

namespace CleanDesign.Application.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string? Email { get; set; }
        public string? OTP { get; set; }
        public required string NewPassword { get; set; }
        public string? OldPassword { get; set; }
        public ResetPasswordMethod ResetPasswordMethod { get; set; }
    }
}
