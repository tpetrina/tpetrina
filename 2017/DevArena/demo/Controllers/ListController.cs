using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[Controller]")]
    public class ListController : Controller
    {
        public IActionResult Get()
        {
            return Ok(new[]
            {
                new {id=1, name="john"}
            });
        }
    }
}