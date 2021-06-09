using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsListBackEnd.Entities
{
    [Table("Film",Schema="dbo")]
    public class Film
    {
       [Key]
       public Guid FilmId { get; set; }

       public string Genre { get; set; }

       [Required]
       public string FilmName { get; set; }

       [Required]
       public string DirectorName { get; set; }
    }
}
