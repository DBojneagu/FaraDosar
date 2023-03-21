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

        public DateTime? DateOfAppointmentStart { get; set; }
        [Required(ErrorMessage = "Ora este obligatorie")]
        public int? HourId { get; set; }

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
