using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {

        [HttpGet("simple")]
        public ActionResult<string> Simple() {
            return Ok("Hallo Welt");
        }

        [HttpGet("parameter")]
        public ActionResult<string> Parameter([FromQuery] string msg) {
            return Ok(msg);
        }

        [HttpGet("validate/{msg}")]
        public ActionResult<string> Validate([FromRoute] string msg = null) {
            if (string.IsNullOrWhiteSpace(msg)) {
                return BadRequest();
            }
            return Ok(msg);
        }
    }
}
