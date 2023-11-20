using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoDotNet8AuthenticationWithIdentityInWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

   
        [HttpPost("add-user")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new AppUser()
            {
                Fullname = model.Email,
                Email = model.Email,
                Contact = model.Contact,
                Address = model.Address,
                UserName = model.Email,
                PasswordHash = model.Password,
            };
            var result = await userManager.CreateAsync(user, user.PasswordHash!);
            if (result.Succeeded)
                return Ok("Registration made successfully");
            
            return BadRequest("Error occured");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var signInResult = await signInManager.PasswordSignInAsync(
                  userName: email!,
                  password: password!,
                  isPersistent: false,
                  lockoutOnFailure: false
                  );
            if (signInResult.Succeeded)
            {
                return Ok("You are successfully logged in");
            }
            return BadRequest("Error occured");
        }
    }
}
