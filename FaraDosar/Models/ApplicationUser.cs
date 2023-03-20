using Microsoft.AspNetCore.Identity;

namespace FaraDosar.Models
{
    public class ApplicationUser : IdentityUser
    {

        public virtual ICollection<Card>? Cards { get; set; }
    }
}
