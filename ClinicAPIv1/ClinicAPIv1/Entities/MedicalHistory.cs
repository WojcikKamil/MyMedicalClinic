using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Entities
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public ClinicUser Patient { get; set; }
        public string PatientEmail { get; set; }
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
    }
}
