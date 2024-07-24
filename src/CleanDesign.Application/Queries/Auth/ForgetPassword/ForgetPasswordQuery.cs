using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Queries.Auth.ForgetPassword
{
    public class ForgetPasswordQuery : IRequest<Result>
    {
        public required string Email { get; set; }
    }
}
