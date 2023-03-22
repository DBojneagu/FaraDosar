using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public enum AppointmentType
{
    InscriereUniversitate,
    CautareLocMunca,
    ObtinereSurseFinantare
}

namespace FaraDosar.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        // val posibile inscriereUniversitate, cautareLocMunca, obtinereSurseFinantare
        [EnumDataType(typeof(AppointmentType))]
        public AppointmentType? AppointmentFor { get; set; }

        [DataType(DataType.Date)]

        public DateTime DateOfAppointmentStart { get; set; }
        [Required(ErrorMessage = "Ora este obligatorie")]
        public int? HourId { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        public string? Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        public string? Prenume { get; set; }

        [Required(ErrorMessage = "Numarul de telefon este obligatoriu")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Numarul de telefon trebuie sa aibe 10 caractere")]
        public string? NrTel { get; set; }

        [Required(ErrorMessage = "CNP-ul este obligatoriu")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "CNP-ul are trebuie sa aiba 13 caractere")]
        public string? CNP { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? Ore { get; set; }
        public virtual Hour? Hour { get; set; }

        public int? LocationId { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? Locations { get; set; }
        public virtual Location? Location { get; set; }

        public string? UserId { get; set; }

        // PASUL 6 - useri si roluri
        public virtual ApplicationUser? User { get; set; }
    }
}
