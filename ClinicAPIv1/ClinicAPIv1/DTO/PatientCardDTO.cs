using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class PatientCardDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public string SecondName { get; set; }
        [Required]
        public string IDCard { get; set; }
        public string PassportCard { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string Voivodeship { get; set; }
        [Required]
        [StringLength(11)]
        public string PESEL { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HomeNumber { get; set; }
        [Required]
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

    }
}
