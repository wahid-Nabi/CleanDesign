namespace CleanDesign.Application.ViewModels
{
    public class TokenViewModel
    {
        public string? BearerToken { get; set; }
        public string? RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
