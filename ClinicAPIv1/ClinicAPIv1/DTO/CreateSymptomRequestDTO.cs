using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class CreateSymptomRequestDTO
    {
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string WorryingSymptom { get; set; }
    }
}
