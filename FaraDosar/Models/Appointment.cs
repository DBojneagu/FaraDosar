using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Selectarea este obligatorie!")]
        public AppointmentType? AppointmentFor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateOfAppointmentStart { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile? Profile { get; set; }
    }
}
