using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(ClinicUser clinicUser);
    }
}
