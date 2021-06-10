using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmsListBackEnd.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FilmsListBackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilmListController : ControllerBase
    {
        private readonly FilmListContext _context;

        public UserFilmListController(FilmListContext context)
        {
            _context = context;
        }

        // GET: api/UserFilmList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFilmList>>> GetUserFilmLists()
        {
            return await _context.UserFilmLists.ToListAsync();
        }

        // GET: api/UserFilmList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFilmList>> GetUserFilmList(Guid id)
        {
            var userFilmList = await _context.UserFilmLists.FindAsync(id);

            if (userFilmList == null)
            {
                return NotFound();
            }

            return userFilmList;
        }

        // PUT: api/UserFilmList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFilmList(Guid id, UserFilmList userFilmList)
        {
            if (id != userFilmList.Id)
            {
                return BadRequest();
            }

            _context.Entry(userFilmList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFilmListExists(id))
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

        // POST: api/UserFilmList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserFilmList>> PostUserFilmList(UserFilmList userFilmList)
        {
            _context.UserFilmLists.Add(userFilmList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserFilmList", new { id = userFilmList.Id }, userFilmList);
        }

        // DELETE: api/UserFilmList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFilmList(Guid id)
        {
            var userFilmList = await _context.UserFilmLists.FindAsync(id);
            if (userFilmList == null)
            {
                return NotFound();
            }

            _context.UserFilmLists.Remove(userFilmList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserFilmListExists(Guid id)
        {
            return _context.UserFilmLists.Any(e => e.Id == id);
        }
    }
}
