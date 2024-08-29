namespace CleanDesign.Application.ViewModels
{
    public class ConfirmEmailViewModel
    {
        public required string Token { get; set; }
        public required string Username { get; set; }
    }
}
