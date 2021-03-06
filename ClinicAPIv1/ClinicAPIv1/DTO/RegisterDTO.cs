using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        public int AccesCode { get; set; }

    }
}
