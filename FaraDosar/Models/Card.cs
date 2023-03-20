using System.ComponentModel.DataAnnotations;

namespace FaraDosar.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Titlul este obligatoriu")]
        [StringLength(100, ErrorMessage = "Titlul nu poate avea mai mult de 100 de caractere")]
        [MinLength(5, ErrorMessage = "Titlul trebuie sa aiba mai mult de 5 caractere")]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
