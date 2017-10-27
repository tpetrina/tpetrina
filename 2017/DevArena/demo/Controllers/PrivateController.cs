using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class PrivateController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { Message = "text" });
    }
}