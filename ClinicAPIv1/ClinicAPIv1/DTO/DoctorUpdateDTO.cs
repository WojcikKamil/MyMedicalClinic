using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class DoctorUpdateDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Introduction { get; set; }
        public string Specialization { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string University { get; set; }
        public DateTime GraduationTime { get; set; }
        public string PostgraduateEducation { get; set; }
        public string AcademicDegree { get; set; }
    }
}
