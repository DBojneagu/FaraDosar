using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FaraDosar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        // de testat regexul
        /*[RegularExpression(@"^[1-9]\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])(0[1-9]|[1-4]\d|5[0-2]|99)(00[1-9]|0[1-9]\d|[1-9]\d\d)\d$", ErrorMessage = "CNP este invalid!")]*/
        public string? CNP { get; set; }

        public string? Adresa { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

    }
}
