using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsListBackEnd.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmsListBackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersFilmsController : Controller
    {
        private readonly FilmListContext _context;

        public UsersFilmsController(FilmListContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<Film>>> UserEmailList(string userEmail)
        {
            var userFilmList = await _context.UserFilmLists.Where(x => x.UserEmail == userEmail).ToListAsync();

            if (userFilmList == null)
            {
                return NotFound();
            }

            var filmIdList = userFilmList.Select(x => x.FilmId);

            List<Film> films = new List<Film>();

            foreach(var filmId in filmIdList)
            {
               films.Add(await _context.Films.Where(x => x.FilmId == filmId).SingleAsync());
            }
            

            return films;
        }
    }
}
