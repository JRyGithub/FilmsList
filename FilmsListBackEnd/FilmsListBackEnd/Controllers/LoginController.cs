using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmsListBackEnd.Entities;
using FilmsListBackEnd.Services;

namespace FilmsListBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly FilmListContext _context;

        public LoginController(FilmListContext context)
        {
            _context = context;
        }

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
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
