using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;

namespace CleanDesign.Application.Abstractions
{
    public interface IEmailSender
    {
        Result SendEmail(EmailViewModel model);
    }
}
