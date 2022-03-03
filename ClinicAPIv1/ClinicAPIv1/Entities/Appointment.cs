using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DoctorEmail { get; set; }
        public string PatientEmail { get; set; }
        public ClinicUser Doctor { get; set; }
        public ClinicUser Patient { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorSpecialization { get; set; }
        public string PatientPesel { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Medicines { get; set; }
        public string Dose { get; set; }
        public string RecommendedDose { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
    }
}
