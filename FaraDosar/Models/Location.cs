using System.ComponentModel.DataAnnotations;
namespace FaraDosar.Models
{
    public class Location
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        public string Name { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
