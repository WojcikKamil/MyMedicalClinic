using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface IUserRepository
    {
        void Update(ClinicUser clinicUser);
        
        //Task<IEnumerable<ClinicUser>> GetDoctors();
        //Task<ClinicUser> GetDoctorById(int id);
        Task<ClinicUser> GetUserByEmail(string userName);
        Task<ClinicUser> GetDoctorByEmail(string userName);
        Task<PagedList<MemberDTO>> GetDoctors(UserParams userParams, FilteringProperties filter=null);
        Task<MemberDTO> GetDoctor(int id);
        Task<MemberDTO> GetPatient(int id);
        Task<MemberDTO> PatientByEmail(string userName);
        Task<ClinicUser> GetPatientByEmail(string userName);
        Task<MemberDTO> GetMemberByEmail(string userName);
        //Task<IEnumerable<ClinicUser>> GetPatients();



    }
}
