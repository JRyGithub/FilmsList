using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsListBackEnd.Entities
{
    [Table("UserFilms", Schema = "dbo")]
    public class UserFilms
    {

        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        [ForeignKey("UserEmail")]
        public User UserEmail { get; set; }

        [Key]
        public Guid Id { get; set; }

    }
}