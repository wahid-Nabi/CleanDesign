using MediatR;
using CleanDesign.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace CleanDesign.Application.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<Result<bool>>
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
