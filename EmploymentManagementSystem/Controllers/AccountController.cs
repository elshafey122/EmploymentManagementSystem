using EmployeeManagementSystem.Core;
using EmployeeManagementSystem.Core.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected readonly UserManager<IdentityUser> _usermanager;
        protected readonly RoleManager<IdentityRole> _rolemanager;
        public AccountController(UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult>Register([FromBody] Register regester,string Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(regester);
            }
            var user = await _usermanager.FindByEmailAsync(regester.Email);
            if (user != null)
            {
                return BadRequest("this email is already exists");
            }
            var newuser = new IdentityUser
            {
                UserName = regester.UserName,
                Email = regester.Email,
            };
            if (!await _rolemanager.RoleExistsAsync(Role))
            {
                return BadRequest("role is not allowed");
            }
            IdentityResult result = await _usermanager.CreateAsync(newuser, regester.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }
            await _usermanager.AddToRoleAsync(newuser, Role);
            return Ok("added");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login userlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityUser user = await _usermanager.FindByNameAsync(userlog.UserName);
            if (user == null)
            {
                return Unauthorized("Username is not correct");
            }
            bool found = await _usermanager.CheckPasswordAsync(user, userlog.Password);
            if (!found)
            {
                return Unauthorized("password is not correct");
            }
            var myclaims = new List<Claim>();
            myclaims.Add(new Claim(ClaimTypes.Name, user.UserName));
            myclaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            myclaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var rules = await _usermanager.GetRolesAsync(user);
            foreach (var rule in rules)
            {
                myclaims.Add(new Claim(ClaimTypes.Role, rule));
            }

            SecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            SigningCredentials mysigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken mytoken = new JwtSecurityToken(
                issuer: "https://localhost:44372/",
                audience: "https://localhost:4200/",
                claims: myclaims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: mysigningCredentials
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                expiration = mytoken.ValidTo
            });
        }
    }
}
