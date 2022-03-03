using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
   public interface IPrescriptionRepository
    {
        void Update(Prescription prescription);
        void AddPrescription(Prescription prescription);
        void DeletePrescription(Prescription prescription);
        Task<Prescription> GetPrescriptionByID(int id);
        Task<PrescriptionDTO> GetPrescription(int id);
        Task<PrescriptionStatusDTO> GetOnePrescription(int id);
        Task<IEnumerable<PrescriptionDTO>> GetActivePrescriptions(string currentUserName);
        Task<IEnumerable<PrescriptionDTO>> GetActivePrescriptionsV1(string currentUserName, string specialization);
        Task<IEnumerable<PrescriptionDTO>> GetConfirmedPrescriptions(string currentUserName);
        Task<IEnumerable<PrescriptionDTO>> GetRejectedPrescriptions(string currentUserName);
        Task<IEnumerable<PrescriptionDTO>> GetRequestHistory(string currentUserName);
        Task<IEnumerable<PrescriptionDTO>> GetPatientsWrittenOutMedicines(string UserName);
    }
}
