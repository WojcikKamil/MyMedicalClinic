using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ISymptomRepository SymptomRepository { get; }
        IMessageRepository MessageRepository { get; }
        IPrescriptionRepository PrescriptionRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        ICodeAcessRepository CodeAcessRepository { get; }
        Task<bool> Complete();
    }
}
