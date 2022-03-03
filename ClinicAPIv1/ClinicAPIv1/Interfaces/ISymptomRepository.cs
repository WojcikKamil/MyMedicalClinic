using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface ISymptomRepository
    {
        void Update(Symptom symptom);
        void AddSymptom(Symptom symptom);
        void DeleteSymptom(Symptom symptom);
        Task<Symptom> GetSymptomById(int id);
        Task<SymptomDTO> GetSymptom(int id);
        Task<SymptomDoctorAnswerDTO> GetOneSymptom(int id);
        Task<IEnumerable<SymptomDTO>> GetActiveSymptomRequest(string currentUserName, string specialization);
        Task<IEnumerable<SymptomDTO>> GetAnswederSymptomRequest(string currentUserName);
        Task<IEnumerable<SymptomDTO>> GetRequestHistory(string currentUserName);
        Task<IEnumerable<SymptomDTO>> GetAnsweredRequestHistory(string currentUserName);
    }
}
