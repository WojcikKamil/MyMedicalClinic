using ClinicAPIv1.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClinicAPIv1.Entities
{
    public class ClinicUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AcademicDegree { get; set; }

        //Office
     

        [JsonIgnore]
        public ICollection<Photo> Photos { get; set; }
        public string TemporaryRole { get; set; }

        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<ClinicUserRole> ClinicRoles { get; set; }




        //New table PatientCard in future
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


        //Also another tabel
        public string LifeDisease { get; set; }
        public string Treatments { get; set; }
        public string Allergies { get; set; }
        public string BloodGroup { get; set; }
        public string MedicationsTakenPernamently { get; set; }
        //Have the patient experienced or occur: shortness of breath, edema, hives, itching? 
        public string Question1 { get; set; }
        //Has the Patient had any episodes of fainting or unconsciousness? 
        public string Question2 { get; set; }
        //Has the patient undergone any surgery or treatment: irradiation, chemotherapy, treatment with steroids?
        public string Question3 { get; set; }
        //Number of pregnancies + length of pregnancy 
        public string Question4 { get; set; }
        //Number of births + dates of births
        public string Question5 { get; set; }
        //Is the patient insured?
        public string Question6 { get; set; }
        public string NFZward { get; set; }
        public string Employer { get; set; }
        public string PolicyAgreement { get; set; }

        //
        public string University { get; set; }
        public DateTime GraduationTime { get; set; }
        public string PostgraduateEducation { get; set; }

        public int GetSeniority()
        {
            return GraduationTime.CalculateSeniority();
        }
    }
}
