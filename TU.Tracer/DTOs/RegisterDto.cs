using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TU.Tracer.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("(?=.*[a-z])(?=.*[A-Z]).{4,15}$", ErrorMessage ="Password must have upper and lower case character and 4 to 15 characters long!")]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
