using CleanDesign.Application.Auth.Commands.Register;
using CleanDesign.Application.Auth.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanDesign.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
          return Ok(await _sender.Send(query));
        }

        [HttpPost,Route("register")]

        public async Task<IActionResult> Register(RegisterCommand command)
        {
            return Ok(await _sender.Send(command));
        }
    }
}
