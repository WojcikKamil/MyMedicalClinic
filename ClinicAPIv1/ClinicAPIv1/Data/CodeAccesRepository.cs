using AutoMapper;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class CodeAccesRepository : ICodeAcessRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CodeAccesRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddCode(AccesCode accesCode)
        {
            _context.AccesCodes.Add(accesCode);
        }

        public void DeleteCode(AccesCode accesCode)
        {
            _context.AccesCodes.Remove(accesCode);
        }

        public async Task<AccesCode> GetCode(int code)
        {
            return await _context.AccesCodes
                .SingleOrDefaultAsync(x => x.Code == code);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
