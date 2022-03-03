using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class PrescriptionStatusV1DTO
    {
        public int Id { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastName { get; set; }
        public string Status { get; set; }
        public DateTime PrescriptionAccepted { get; set; } = DateTime.Now;
    }
}
