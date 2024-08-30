using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanDesign.Presentation.Controllers
{
    [Route("api/dummy")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public ActionResult GetDummy() => Ok("Hi");
    }
}
