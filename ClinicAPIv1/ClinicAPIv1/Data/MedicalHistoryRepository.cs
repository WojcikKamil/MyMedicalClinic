using AutoMapper;
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
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public MedicalHistoryRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMedicalHistory(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Add(medicalHistory);
        }

        public async Task<IEnumerable<MedicalHistoryUpdateDTO>> GetMedicalHistoryv1(string UserName)
        {
            var medicalhistory = await _context.MedicalHistories
             .Where(x => x.PatientEmail == UserName)
             .ToListAsync();

            return _mapper.Map<IEnumerable<MedicalHistoryUpdateDTO>>(medicalhistory);
        }

        public Task<MedicalHistoryUpdateDTO> GetMedicalHistory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalHistory> GetMedicalHistoryByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MedicalHistory> GetMedicalHistoryByUserName(string UserName)
        {
            return await _context.MedicalHistories
                .SingleOrDefaultAsync(x => x.PatientEmail == UserName);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(MedicalHistory medicalHistory)
        {
            _context.Entry(medicalHistory).State = EntityState.Modified;
        }

        public async Task<MedicalHistoryUpdateDTO> GetMedicalHistory(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
