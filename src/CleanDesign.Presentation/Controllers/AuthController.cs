using CleanDesign.Application.Auth.Commands.Register;
using CleanDesign.Application.Auth.Queries.Login;
using CleanDesign.Application.ViewModels;
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
          Result<TokenViewModel> result = await _sender.Send(query);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }
          return Ok(result);
        }

        [HttpPost,Route("register")]

        public async Task<IActionResult> Register(RegisterCommand command)
        {
            return Ok(await _sender.Send(command));
        }
    }
}
