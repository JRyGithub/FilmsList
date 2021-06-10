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
    public class UserController : ControllerBase
    {
        private readonly FilmListContext _context;

        public UserController(FilmListContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/{User Email}
        [HttpGet("{userEmail}")]
        public async Task<ActionResult<User>> GetUser(string userEmail)
        {
            var user = await _context.Users.FindAsync(userEmail);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/User/{UserEmail}/{password} //LOGIN
        [HttpPost]
        public async Task<ActionResult<User>> GetUser(User user)
        { 
            var userAttempt = await _context.Users.FindAsync(user.UserEmail);
            var attemptedPassword = Utilities.ComputeSha256Hash(user.Password);

            if (user == null)
            {
                return NotFound();
            }
            else if (userAttempt.Password == attemptedPassword)
            {
                return user;
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userEmail}")]
        public async Task<IActionResult> PutUser(string userEmail, User user)
        {
            if (userEmail != user.UserEmail)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userEmail))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            user.Password = Utilities.ComputeSha256Hash(user.Password);


            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { userEmail = user.UserEmail }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{userEmail}")]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            var user = await _context.Users.FindAsync(userEmail);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string userEmail)
        {
            return _context.Users.Any(e => e.UserEmail == userEmail);
        }
    }
}
