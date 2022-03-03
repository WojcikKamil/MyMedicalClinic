using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Helpers;
using ClinicAPIv1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserRepository()
        {
        }

        public async Task<ClinicUser> GetUserByEmail(string UserName)
        {
            return await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == UserName);
        }

        //public async Task<ClinicUser> GetDoctorById(int id)
        //{
        //    return await _context.Users
        //       .Where(x => x.TemporaryRole == "Doctor")
        //       .Include(p => p.Photos)
        //       .SingleOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<IEnumerable<ClinicUser>> GetDoctors()
        //{
        //    return await _context.Users
        //        .Include(p=>p.Photos)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<ClinicUser>> GetPatients()
        //{
        //    return await _context.Users
        //        .Where(x => x.TemporaryRole == "Patient")
        //        .ToListAsync();
        //}

        public void Update(ClinicUser clinicUser)
        {
            _context.Entry(clinicUser).State = EntityState.Modified;
        }

        public async Task<PagedList<MemberDTO>> GetDoctors
            (UserParams userParams, FilteringProperties filter = null)
        {
            var query = _context.Users
                .Where(x => x.TemporaryRole == "Doctor")
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking();

           if (filter != null)
                {
                query = query.Where(m =>
                m.Specialization.Contains(filter.BySpecialization));
            }

            return await PagedList<MemberDTO>.Create(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<MemberDTO> GetDoctor(int id)
        {
            return await _context.Users
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MemberDTO> GetMemberByEmail(string userName)
        {
            return await _context.Users
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<ClinicUser> GetDoctorByEmail(string userName)
        {
            return await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<MemberDTO> GetPatient(int id)
        {
            return await _context.Users
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ClinicUser> GetPatientByEmail(string userName)
        {
            return await _context.Users
                 .Include(p => p.Photos)
                 .SingleOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<MemberDTO> PatientByEmail(string userName)
        {
            return await _context.Users
               .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
