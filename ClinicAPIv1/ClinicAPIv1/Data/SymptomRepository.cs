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
    public class SymptomRepository : ISymptomRepository
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public SymptomRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddSymptom(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
        }

        public void DeleteSymptom(Symptom symptom)
        {
            _context.Symptoms.Remove(symptom);
        }

        public async Task<IEnumerable<SymptomDTO>> GetActiveSymptomRequest(string currentUserName, string specialization)
        {
            var symptom = await _context.Symptoms
                 .Where(s => s.Specialization == specialization)
                 .Where(y => y.DoctorAnswer.Length == 0)
                 .OrderByDescending(m => m.SymptomRequestSent)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<SymptomDTO>>(symptom);
        }

        public async Task<IEnumerable<SymptomDTO>> GetAnswederSymptomRequest(string currentUserName)
        {
            var symptom = await _context.Symptoms
                 .Where(x => x.DoctorEmail == currentUserName)
                 .Where(y => y.DoctorAnswer.Length > 0)
                 .OrderByDescending(m => m.SymptomRequestSent)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<SymptomDTO>>(symptom);
        }

        public async Task<SymptomDoctorAnswerDTO> GetOneSymptom(int id)
        {
            return await _context.Symptoms
               .ProjectTo<SymptomDoctorAnswerDTO>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SymptomDTO>> GetRequestHistory(string currentUserName)
        {
            var symptom = await _context.Symptoms
               .Where(x => x.PatientEmail == currentUserName && x.DoctorAnswer.Length == 0 )
               .OrderByDescending(m => m.SymptomRequestSent)
               .ToListAsync();

            return _mapper.Map<IEnumerable<SymptomDTO>>(symptom);
        }

        public async Task<IEnumerable<SymptomDTO>> GetAnsweredRequestHistory(string currentUserName)
        {
            var symptom = await _context.Symptoms
                .Where(x => x.PatientEmail == currentUserName && x.DoctorAnswer.Length > 0)
               .OrderByDescending(m => m.SymptomRequestSent)
               .ToListAsync();

            return _mapper.Map<IEnumerable<SymptomDTO>>(symptom);
        }

        public async Task<SymptomDTO> GetSymptom(int id)
        {
            return await _context.Symptoms
                .ProjectTo<SymptomDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Symptom> GetSymptomById(int id)
        {
            return await _context.Symptoms
                 .SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Symptom symptom)
        {
            _context.Entry(symptom).State = EntityState.Modified;
        }
    }
}
