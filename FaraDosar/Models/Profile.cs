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

        // de testat regexul
        /*[RegularExpression(@"^[1-9]\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])(0[1-9]|[1-4]\d|5[0-2]|99)(00[1-9]|0[1-9]\d|[1-9]\d\d)\d$", ErrorMessage = "CNP este invalid!")]*/
        public string? CNP { get; set; }

        public string? Adresa { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Numarul de telefon invalid!")]
        public string? PhoneNumber { get; set; }

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    
        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}