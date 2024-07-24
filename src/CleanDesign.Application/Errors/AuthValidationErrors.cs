using CleanDesign.SharedKernel;

namespace CleanDesign.Application.Errors
{
    public class AuthValidationErrors
    {
        public static readonly Error EmailNull = new("AuthValidation.EmailNull", "The specified email is null, please enter a valid email.");
        public static readonly Error EmailNotRegistered = new("AuthValidation.EmailNotRegistered", "The entered email is not registered. ");
    }
}
