using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class CreatePrescriptionRequestDTO
    {
        public string DoctorUserName { get; set; }
        [Required]
        public string Specialization { get; set; }
        public string Medicines { get; set; }
        public string Dose { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
