using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrepaidSystemContext.Enum;
using ReportViewer.Models;

namespace ReportViewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PrepaidSystemContext.PrepaidSystemContext prepaidSystemContext;

        public AuthController(PrepaidSystemContext.PrepaidSystemContext prepaidSystemContext)
        {
            this.prepaidSystemContext = prepaidSystemContext;
        }

        // GET api/values
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (this.CanBeAuthenticated(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44364",
                    audience: "https://localhost:44364",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new {Token = tokenString});
            }

            return Unauthorized();
        }

        private bool CanBeAuthenticated(LoginModel user)
        {
            var hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            var dbUser = this.prepaidSystemContext.User.SingleOrDefault(n => n.Username == user.UserName);

            if (dbUser != null && dbUser.PasswordSHA256.SequenceEqual(hash) && dbUser.Role == UserRoleType.Administrator)
            {
                return true;
            }
            return false;
        }
    }
}