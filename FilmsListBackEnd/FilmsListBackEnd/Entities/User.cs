using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsListBackEnd.Entities
{
    [Table("User", Schema = "dbo")]
    public class User
    { 
        [Key]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
