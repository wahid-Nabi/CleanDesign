using CleanDesign.SharedKernel;

namespace CleanDesign.Domain.Errors
{
    public static class GenericAuthErrors
    {
        public static readonly Error InvalidEmail = new(
            "Auth.InvalidEmail",
            "Provided email is not valid!");

    }
    public static class LoginErrors
    {
        public static readonly Error UserNotFound = new(
            "Auth.UserNotFound",
            "Entered email is not associated with any account!");


        public static readonly Error InvalidCredentials = new(
            "Auth.InvalidCredentials",
            "Invalid credentials!");

        public static readonly Error LoginFailed = new(
            "Auth.LoginFailed",
            "Login Failed!");
    }

    public static class UserRegisterErrors
    {
        public static readonly Error RegistrationFailed = new(
            "Auth.Register Failed",
            "User registration failed"
            );
        public static readonly Error WeakPassword = new(
            "Auth.Poor Password",
            "Password must contain at least 1 number, 1 letter and 1 special character!"
            );
    }
}
