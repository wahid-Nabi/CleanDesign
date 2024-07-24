
using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;

namespace CleanDesign.Application.Commands.Auth.ConfirmPassword
{
    public class ConfirmEmailCommand : IRequest<Result>
    {
        public required string Token { get; set; }
        public required string Username { get; set; }

    }
}
