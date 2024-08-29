
namespace CleanDesign.Application.ViewModels
{
    public class ValidateTwoFactorTokenViewModel
    {
        public required string  OTP { get; set; }
        public required string Email { get; set; }
    }
}
