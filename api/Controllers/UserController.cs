using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private IOptions<AudienceModel> _setting;
        public UserController(IRepositoryWrapper repoWrapper, IOptions<AudienceModel> setting)
        {
            _repoWrapper = repoWrapper;
            _setting = setting;
        }

        [HttpPost("login")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Login([FromForm] LoginDto login)
        {
            try
            {
                var user = await _repoWrapper.UserRepository.Login(login.Email, login.Password);
                if (user != null)
                {
                    if(user.IsDel == true) {
                        return BadRequest("Your account is inactive. Please contact your administrator for more information.");
                    }

                    string[] roles = new string[] { };
                    var userRoles = user.UserRoles;
                    if (userRoles != null && userRoles.Count() > 0)
                    {
                        roles = userRoles.Select(x => x.Role.RoleCode).ToArray();
                    }
                    var token = GenerateJwtToken(
                        user.UserId.ToString(), user.Email, _setting.Value.Iss, _setting.Value.Secret, _setting.Value.Aud, 
                        DateTime.UtcNow.AddDays(1), roles, user.FirstName + " " + user.LastName
                    );

                    var response = new
                    {
                        access_token = token,
                        expires_in = (int)TimeSpan.FromHours(24).TotalSeconds,
                        token_type = "Bearer",
                        user_id = user.UserId,
                        roles = string.Join(",", roles),
                        email = user.Email
                    };

                    return Ok(response);
                }

                return BadRequest("Your account is not valid. Please check your login information.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            try
            {
                var user = await _repoWrapper.UserRepository.GetUser(userId);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static string GenerateJwtToken(string userId, string email, string iss, string secret, string aud, DateTime expireOn, string[] roles, string fullName)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, fullName),
                new Claim(ClaimTypes.Email, email),
                // new Claim(ClaimTypes.UserData, userType),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
            }.ToList();

            // set role
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var symmetricKeyAsBase64 = secret;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var jwt = new JwtSecurityToken(
                issuer: iss,
                audience: aud,
                claims: claims,
                notBefore: now,
                expires: expireOn,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}