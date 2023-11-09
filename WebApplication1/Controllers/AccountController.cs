using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<VoyageUser> userManager;

        public AccountController(UserManager<VoyageUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: api/<AccountController>
        [HttpPost]
        public async Task<ActionResult> Register( RegisterDTO register)
        {
            if(register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            VoyageUser user = new VoyageUser()
            {
                UserName = register.UserName,
                Email = register.Email
            };

            IdentityResult identityResult = await this.userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult);
            }

            return Ok();
        }

        
    }
}
