using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    public class RegisterViewModel { }

    [Route("[Controller]")]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(
            [FromServices]UserManager<IdentityUser> userManager,
            [FromServices]SignInManager<IdentityUser> signInManager
        )
        {
            var user = await userManager.FindByEmailAsync("test@test.com");
            if (user == null)
            {
                var r = await userManager.CreateAsync(new IdentityUser
                {
                    Email = "test@test.com",
                    UserName = "test@test.com"
                }, "Pa$$w0rd");

                if (!r.Succeeded)
                    return BadRequest(r.Errors);
            }

            var result = await signInManager.PasswordSignInAsync("test@test.com", "Pa$$w0rd", false, lockoutOnFailure: false);
            if (result.Succeeded)
                return Ok();

            return BadRequest(result);
        }

        [HttpPost, Route("logout")]
        public async Task<IActionResult> Logout(
            [FromServices]SignInManager<IdentityUser> signInManager
        )
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(
            [FromServices]UserManager<IdentityUser> userManager
            )
        {
            var result = await userManager.CreateAsync(new IdentityUser
            {
                Email = "test@test.com",
            }, "Pa$$w0rd");

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}