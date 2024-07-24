using CleanDesign.Application.Commands.Auth.ConfirmPassword;
using CleanDesign.Application.Commands.Auth.Register;
using CleanDesign.Application.Commands.Auth.ResetPassword;
using CleanDesign.Application.Queries.Auth.ForgetPassword;
using CleanDesign.Application.Queries.Auth.Login;
using CleanDesign.Application.Queries.Auth.RefreshToken;
using CleanDesign.Application.Queries.Auth.ValidateToken;
using CleanDesign.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanDesign.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<AuthController> _logger;
        public AuthController(ISender sender, ILogger<AuthController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            Result result = await _sender.Send(query);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result);
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpPost, Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenQuery query)
        {
            var result = await _sender.Send(query);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }

        [HttpGet("forget-password/{email}")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            var query = new ForgetPasswordQuery()
            {
                Email = email
            };
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetCommand)
        {
            var result = await _sender.Send(resetCommand);
            return Ok(result);
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpPost("verify-two-factor-token")]
        public async Task<IActionResult> ValidateTwoFactorToken(ValidateTwoFactorTokenQuery query)
        {
            var response = await _sender.Send(query);
            return Ok(response);
        }

    }
}
