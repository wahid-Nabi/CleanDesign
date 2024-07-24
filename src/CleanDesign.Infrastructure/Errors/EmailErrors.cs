using CleanDesign.SharedKernel;

namespace CleanDesign.Infrastructure.Errors
{
    public class EmailErrors
    {
        public static readonly Error FailedToSendEmail = new(
            "EmailService.FailedToSendEmail",
            "Failed to send the email!");
    }
}
