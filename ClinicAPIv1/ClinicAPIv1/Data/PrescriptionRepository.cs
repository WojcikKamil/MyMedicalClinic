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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PrescriptionRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddPrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
        }

        public void DeletePrescription(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
        }

        public async Task<PrescriptionDTO> GetPrescription(int id)
        {
            return await _context.Prescriptions
                .ProjectTo<PrescriptionDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetActivePrescriptions(string currentUserName)
        {
            var prescription = await _context.Prescriptions
                .Where(x => x.DoctorEmail == currentUserName)
                .Where(y => y.Status == "Waiting")
                .OrderByDescending(m => m.PrescriptionRequestSent)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescription);
        }



        public async Task<IEnumerable<PrescriptionDTO>> GetActivePrescriptionsV1(string currentUserName, string specialization)
        {
            var prescription = await _context.Prescriptions
                .Where(y => y.Status == "Waiting")
                .Where(s => s.Specialization == specialization)
                .OrderByDescending(m => m.PrescriptionRequestSent)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescription);

        }

            public async Task<IEnumerable<PrescriptionDTO>> GetRequestHistory(string currentUserName)
        {
            var prescription = await _context.Prescriptions
                .Where(x => x.PatientEmail == currentUserName)
                .OrderByDescending(m => m.PrescriptionRequestSent)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescription); 
        }

        public async Task<PrescriptionStatusDTO> GetOnePrescription(int id)
        {
            //return await _context.Messages.FindAsync(id);
            return await _context.Prescriptions
                .ProjectTo<PrescriptionStatusDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Prescription prescription)
        {
            _context.Entry(prescription).State = EntityState.Modified;
        }

        public async Task<Prescription> GetPrescriptionByID(int id)
        {
            return await _context.Prescriptions
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetConfirmedPrescriptions(string currentUserName)
        {
            var prescription = await _context.Prescriptions
                .Where(x => x.DoctorEmail == currentUserName)
                .Where(y => y.Status == "Confirmed")
                .OrderByDescending(m => m.PrescriptionRequestSent)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescription);
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetRejectedPrescriptions(string currentUserName)
        {
            var prescription = await _context.Prescriptions
                .Where(x => x.DoctorEmail == currentUserName)
                .Where(y => y.Status == "Rejected")
                .OrderByDescending(m => m.PrescriptionRequestSent)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescription);
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetPatientsWrittenOutMedicines(string UserName)
        {
            var prescription = await _context.Prescriptions
                .Where(x => x.PatientEmail == UserName)
                .Where(y => y.Status == "Confirmed")
                .OrderByDescending(m => m.PrescriptionRequestSent)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescription);
                
        }
    }
}
