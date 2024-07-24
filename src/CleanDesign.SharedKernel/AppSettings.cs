namespace CleanDesign.SharedKernel
{
    public class AppSettings
    {
        public required AuthSettings AuthSettings { get; set; }
        public required EmailSettings EmailSettings { get; set; }
        public required string BaseUiUrl { get; set; }

    }

    public class AuthSettings
    {
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string SecretKey { get; set; }
        public required string AppName { get; set; }
        public required string RefreshTokenPurpose { get; set; }
    }

    public class EmailSettings
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int Port { get; set; }
        public required string Host { get; set; }
    }
}
