using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsListBackEnd.Entities
{
    [Table("UserFilmList", Schema="dbo")]
    public class UserFilmList
    {
        [ForeignKey("Film")]
        public Guid FilmId { get; set; }

        [ForeignKey("User")]
        public string UserEmail { get; set; }

        [Key]
        public Guid Id { get; set; }
    }
}
