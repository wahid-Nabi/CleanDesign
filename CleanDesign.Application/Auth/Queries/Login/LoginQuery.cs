using CleanDesign.SharedKernel;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanDesign.Application.Auth.Queries.Login
{
    public class LoginQuery : IRequest<Result<string>>
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
