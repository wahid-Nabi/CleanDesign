using CleanDesign.Application.ViewModels;
using CleanDesign.SharedKernel;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanDesign.Application.Queries.Auth.Login
{
    public class LoginQuery : IRequest<Result>
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
