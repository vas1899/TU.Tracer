using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TU.Tracer.DTOs;
using TU.Tracer.Services;

namespace TU.Tracer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _token;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService token)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
        }

        // POST: api/Account/Login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) {
                return Unauthorized();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.Succeeded) {
                return CreateUserObject(user);
            }
            return Unauthorized();

        }

        // POST: api/Account/Register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var isEmailTaken = await _userManager.Users.AnyAsync(u => u.Email == registerDto.Email);
            if (isEmailTaken) {
                return BadRequest("Email Taken");
            }
            var isUserNameTaken = await _userManager.Users.AnyAsync(u => u.UserName == registerDto.UserName);
            if (isUserNameTaken) {
                return BadRequest("UserName Taken");
            }

            var user = new AppUser { DisplayName = registerDto.DisplayName, Email = registerDto.Email, UserName = registerDto.UserName };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded) {
                return CreateUserObject(user);
            }

            return BadRequest("Error while registering!!");

        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return CreateUserObject(user);
        }

        private ActionResult<UserDto> CreateUserObject(AppUser user)
        {
            return new UserDto {
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Image = null,
                Token = _token.CreateToken(user)
            };
        }
    }
}
