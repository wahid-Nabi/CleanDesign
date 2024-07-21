using CleanDesign.SharedKernel;

namespace CleanDesign.Application.Errors
{
    public class AuthValidationErrors
    {
        public static readonly Error EmailNull = new("AuthValidation.EmailNull", "The specified email is null, please enter a valid email.");
    }
}
