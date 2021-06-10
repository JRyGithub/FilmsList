using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FilmsListBackEnd.Entities
{
    public class FilmListContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<UserFilmList> UserFilmLists { get; set; }

        public FilmListContext(DbContextOptions<FilmListContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<UserFilmList>().ToTable("UserFilmList");            
        }
    }
}
