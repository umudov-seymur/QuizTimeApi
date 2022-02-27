using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NETCore.MailKit.Core;
using Quiztime.Core.Entities;
using Quiztime.Core.Enums;
using QuizTime.Business.DTOs.Authentication;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.DTOs.User;
using QuizTime.Business.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace QuizTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;

        public AuthenticateController(

            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IEmailService emailService,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto register)
        {
            AppUser IsEmailExist = await _userManager.FindByEmailAsync(register.Email);
            if (IsEmailExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "Email is already exist" });
            }

            AppUser appUser = new AppUser
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Email
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, register.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new Response { Status = error.Code, Message = error.Description });
                }
            }

            await _userManager.AddToRoleAsync(appUser, ((Roles)register.Role).ToString());

            #region Email Confirmation

            var cToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            cToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(cToken));

            var confirmationUrl = Url.Action("ConfirmEmail", "Authenticate", new
            {
                email = appUser.Email,
                code = cToken
            }, protocol: HttpContext.Request.Scheme);

            string message = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(confirmationUrl)}'>Confirm Account</a>.";

            await _emailService.SendAsync(register.Email, "Confirm your email", message, isHtml: true);

            #endregion

            return Ok(new Response { Status = "Success", Message = "You have successfully registered. Please, confirm you account." });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
                return NotFound(new Response { Status = "Not Found Account", Message = "There is no such user in the system." });

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized(new Response { Status = "Error", Message = "Email or Password is not correct" });

            if (user.EmailConfirmed == false)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                        new Response
                        {
                            Status = "Not Verified Email",
                            Message = "Please check your inbox and you confirm account."
                        });
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var token = await _jwtService.GenerateToken(user, userRoles);

            var userData = new UserGetDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = userRoles
            };

            return Ok(new
            {
                user = userData,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost("ConfirmEmail/{email}/{code}")]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            if (email == null || code == null)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "Email or Token is not exist." }
                );
            }

            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user is null) return NotFound();

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new Response { Status = error.Code, Message = error.Description });
                }

                return Ok(new { Email = user.Email, Code = code, Error = result.Errors });
            }

            return Ok(new Response { Status = "Success", Message = "Email has been confirmed" });
        }

        #region Create Roles
        //[HttpPost("roles")]
        //public async Task CreateRoles()
        //{
        //    foreach (var item in Enum.GetValues(typeof(Roles)))
        //    {
        //        if (!(await _roleManager.RoleExistsAsync(item.ToString())))
        //        {
        //            await _roleManager.CreateAsync(new AppRole
        //            {
        //                Name = item.ToString()
        //            });
        //        }
        //    }
        //}
        #endregion
    }
}
