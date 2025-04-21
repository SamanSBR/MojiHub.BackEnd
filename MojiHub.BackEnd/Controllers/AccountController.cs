using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MojiHub.BackEnd.Utility;
using MojiHub.Data.DTOs;
using MojiHub.Data.Entities.User;
using MojiHub.Data.Services.Interfaces;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MojiHub.BackEnd.Controllers
{
    [ApiController]
    [Route("api/account")]

    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IViewRenderService _viewRenderService;
        public AccountController(IUserService userService, IJwtService jwtService,IViewRenderService viewRender)
        {
            _userService = userService;
            _jwtService = jwtService;
            _viewRenderService = viewRender;
        }

        #region Register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterViewModel registerViewModel)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //if (_userService.IsEmailExist(registerViewModel.Email))
            //    return BadRequest(new { message = "This Email Exists" });

            var user = new User()
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Password = SecurityService.HashPassword(registerViewModel.Password),
                ActiveCode = Guid.NewGuid().ToString(),
                IsActive = false
            };

            _userService.AddUser(user);
            string link = "http://localhost:5091/api/account/activate?id=" + user.UserId.ToString();
            string body = EmailBodyBuilder.BuildActivationEmail( user.Name, link);
            EmailSender.Send(user.Email, "فعال‌سازی حساب MojiHub Email", body);

            return Ok(new { message = "User registered successfully. Please activate your email." });
        }
        #endregion

        #region Login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userService.GetUserByEmail(loginViewModel.Email);
            if (user == null)
                return Unauthorized(new { message = "Email not found." });

            if (!SecurityService.VerifyPassword(loginViewModel.Password, user.Password))
                return Unauthorized(new { message = "Invalid password." });

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                user = new { user.UserId, user.Name, user.Email }
            });
        }
        #endregion

        #region Activate User
        [HttpGet("activate")]
        public IActionResult ActivateUser(string id)
        {
            var Id=Convert.ToInt16(id);
            var user =_userService.GetUserById(Id);
            var res = _userService.ActiveUser(user.ActiveCode);
            if (res == null)
                return NotFound(new { message = "User not found or already activated." });

            return Ok(new { message = "Account activated successfully." });
        }
        #endregion

        #region Change Password
        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(userId);

            if (!SecurityService.VerifyPassword(model.CurrentPassword, user.Password))
                return BadRequest(new { message = "Current password is incorrect." });

            user.Password = SecurityService.HashPassword(model.NewPassword);
            _userService.UpdateUser(user);

            return Ok(new { message = "Password changed successfully." });
        }
        #endregion

        #region Profile
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            return Ok(new
            {
                user.UserId,
                user.Name,
                user.Email
            });
        }
        #endregion
    }

}
