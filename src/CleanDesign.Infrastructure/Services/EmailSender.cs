using CleanDesign.Application.Abstractions;
using CleanDesign.Application.ViewModels;
using CleanDesign.Infrastructure.Errors;
using CleanDesign.SharedKernel;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CleanDesign.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<AppSettings> appSettings)
        {
            _emailSettings = appSettings.Value.EmailSettings;
        }

        public Result SendEmail(EmailViewModel model)
        {
            MailMessage message = new(_emailSettings.Email, model.To)
            {
                Subject = model.Subject,
                Body = model.Body,
                IsBodyHtml = true
            };
            SmtpClient client = new(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
                EnableSsl = true
              
            };

            try
            {
                client.Send(message);
                return Result.Success();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());

                return Result.Failure(EmailErrors.FailedToSendEmail);
            }
        }
    }
}
