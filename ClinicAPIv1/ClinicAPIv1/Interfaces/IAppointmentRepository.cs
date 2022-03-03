using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface IAppointmentRepository
    {
        void Update(Appointment appointment);
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
        Task<Appointment> GetAppintmentById(int id);
        Task<AppointmentDTO> GetAppintment(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointments(string UserName);
    }
}
