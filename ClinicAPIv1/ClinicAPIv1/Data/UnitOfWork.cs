using AutoMapper;
using ClinicAPIv1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public ISymptomRepository SymptomRepository => new SymptomRepository(_context, _mapper);

        public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);

        public IPrescriptionRepository PrescriptionRepository => new PrescriptionRepository(_context, _mapper);

        public IAppointmentRepository AppointmentRepository => new AppointmentRepository(_context, _mapper);

        public ICodeAcessRepository CodeAcessRepository => new CodeAccesRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
