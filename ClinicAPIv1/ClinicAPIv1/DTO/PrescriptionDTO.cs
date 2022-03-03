using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public string DoctorEmail { get; set; }
        public string PatientEmail { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientPesel { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastName { get; set; }
        public string Specialization { get; set; }
        public string DoctorSpecialization { get; set; }
        public string Medicines { get; set; }
        public string Dose { get; set; }
        public string Content { get; set; }
        public DateTime PrescriptionRequestSent { get; set; }
        public DateTime PrescriptionAccepted { get; set; }
        public string Status { get; set; }
    }
}
