namespace CleanDesign.Application.ViewModels
{
    public class RefreshTokenViewModel(string refreshToken)
    {
        public string RefreshToken { get; set; } = refreshToken;
    }
}
