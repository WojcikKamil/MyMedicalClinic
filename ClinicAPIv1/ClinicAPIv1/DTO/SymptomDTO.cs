using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class SymptomDTO
    {
        public int Id { get; set; }
        public string DoctorEmail { get; set; }
        public string PatientEmail { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorSpecialization { get; set; }
        public string PatientPesel { get; set; }
        public string WorryingSymptom { get; set; }
        public string DoctorAnswer { get; set; }
        public DateTime SymptomRequestSent { get; set; }
    }
}
