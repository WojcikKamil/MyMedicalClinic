using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string AcademicDegree { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; }
        public string TemporaryRole { get; set; }

        public string SecondName { get; set; }
        public string IDCard { get; set; }
        public string PassportCard { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Voivodeship { get; set; }
        public string PESEL { get; set; }
        public string Nationality { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public int FlatNumber { get; set; }

        public string LifeDisease { get; set; }
        public string Treatments { get; set; }
        public string Allergies { get; set; }
        public string BloodGroup { get; set; }
        public string MedicationsTakenPernamently { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
        public string Question6 { get; set; }
        public string NFZward { get; set; }
        public string Employer { get; set; }
        public string PolicyAgreement { get; set; }

        public string University { get; set; }
        public DateTime GraduationTime { get; set; }
        public string PostgraduateEducation { get; set; }
        public string Seniority { get; set; }
    }
}
