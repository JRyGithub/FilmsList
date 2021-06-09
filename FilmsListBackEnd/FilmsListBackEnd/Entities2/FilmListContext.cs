using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FilmsListBackEnd.Entities
{
    public class FilmListContext : DbContext
    {
        public FilmListContext(DbContextOptions<FilmListContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<UserFilms> UserFilms { get; set; }
    }
}
