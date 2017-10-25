using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    [Route("api/[Controller]")]
    public class ListController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices]ApplicationDbContext db
        )
        {
            return Ok(await db.Person.ToListAsync());
        }
    }
}