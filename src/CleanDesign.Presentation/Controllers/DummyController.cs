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
        public ActionResult GetDummy()
        {
            return Ok("Hi");
        }
    }
}
