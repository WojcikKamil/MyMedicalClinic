using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface IMedicalHistoryRepository
    {
        void Update(MedicalHistory medicalHistory);
        void AddMedicalHistory(MedicalHistory medicalHistory);
        Task<MedicalHistory> GetMedicalHistoryByID(int id);
        Task<MedicalHistoryUpdateDTO> GetMedicalHistory(string userName);
        Task<MedicalHistory> GetMedicalHistoryByUserName(string UserName);
        Task<IEnumerable<MedicalHistoryUpdateDTO>> GetMedicalHistoryv1(string UserName);
        Task<bool> SaveAllAsync();
    }
}
