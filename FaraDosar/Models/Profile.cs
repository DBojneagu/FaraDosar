using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FaraDosar.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Numele este obligatoriu")]
        public string? LastName { get; set; }
        public string? Adresa { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Numarul de telefon invalid!")]
        public string? PhoneNumber { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}