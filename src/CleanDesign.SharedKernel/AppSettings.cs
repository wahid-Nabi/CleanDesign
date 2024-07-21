namespace CleanDesign.SharedKernel
{
    public class AppSettings
    {
        public required AuthSettings AuthSettings { get; set; }
    }

    public class AuthSettings
    {
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string SecretKey { get; set; }
        public required string AppName { get; set; }
        public required string RefreshTokenName { get; set; }
    }
}
