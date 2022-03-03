using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class CreateAppointmentDTO
    {
        public string PatientUserName { get; set; }
        [Required]
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Medicines { get; set; }
        public string Dose { get; set; }
        public string RecommendedDose { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
    }
}
