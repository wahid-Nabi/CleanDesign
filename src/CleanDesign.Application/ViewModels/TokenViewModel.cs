namespace CleanDesign.Application.ViewModels
{
    public class TokenViewModel(string bearerToken, string refreshToken)
    {
        public string BearerToken { get; set; } = bearerToken;
        public string RefreshToken { get; set; } = refreshToken;
        public int ExpiresIn { get; set; }
    }
}
