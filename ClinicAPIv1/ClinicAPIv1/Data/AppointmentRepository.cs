using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AppointmentRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }

        public async Task<AppointmentDTO> GetAppintment(int id)
        {
            return await _context.Appointments
                 .ProjectTo<AppointmentDTO>(_mapper.ConfigurationProvider)
                 .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Appointment> GetAppintmentById(int id)
        {
            return await _context.Appointments
                 .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments(string UserName)
        {

            var appointment = await _context.Appointments
               .Where(x => x.PatientEmail == UserName)
               .OrderByDescending(m => m.AppointmentDate)
               .ToListAsync();

            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
        }
    }
}
