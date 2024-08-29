namespace CleanDesign.Application.ViewModels
{
    public class RegisterViewModel
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
