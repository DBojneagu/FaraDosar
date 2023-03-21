using System.ComponentModel.DataAnnotations;
namespace FaraDosar.Models
{
    public class Hour
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        public string Time { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
