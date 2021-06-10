using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmsListBackEnd.Entities;
using FilmsListBackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FilmsListBackEnd.Helpers;

namespace FilmsListBackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly FilmListContext _context;
        private readonly IConfiguration _config;

        private readonly IJwtGenerator _jwtGenerator;

        public LoginController(FilmListContext context, IConfiguration configuration, IJwtGenerator jwtGenerator) { 
            _context = context;
            _config = configuration;
            _jwtGenerator = jwtGenerator;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> Login(User user)
        {
            var userAttempt = await _context.Users.FindAsync(user.UserEmail);
            var attemptedPassword = Utilities.ComputeSha256Hash(user.Password);

            if (user == null)
            {
                return NotFound();
            }
            else if (userAttempt.Password == attemptedPassword)
            {
                //var tokenString = GenerateJSONWebToken(user);


                JwtGenerator token = _jwtGenerator
                    .AddClaim(new Claim(ClaimTypes.Email, user.UserEmail));

                return Ok(new { Token = token.GetToken(), Messaage = "Success", ExpirationInUnixTime = token.GetTokenExpirationInUnixTime });
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
