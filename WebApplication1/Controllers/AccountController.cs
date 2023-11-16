using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<VoyageUser> userManager;
        IConfiguration configuration;

        public AccountController(UserManager<VoyageUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            VoyageUser user = await userManager.FindByNameAsync(login.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, login.Password)) 
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                List<Claim> authClaims = new List<Claim>();
                foreach (string role in roles) 
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                SymmetricSecurityKey authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                JwtSecurityToken token = new JwtSecurityToken
                    (
                        issuer: "https://localhost:7263",
                        audience: "https://localhost:4200",
                        claims: authClaims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    validTo = token.ValidTo
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "L'utilisateur n'a pas le bon mdp ou n'existe pas dans la bd." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register( RegisterDTO register)
        {
            if(register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "L'utilisateur n'a pas le meme mdp de confirm" });
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
