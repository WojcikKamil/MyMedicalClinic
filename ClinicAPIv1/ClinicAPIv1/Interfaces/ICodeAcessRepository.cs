using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface ICodeAcessRepository
    {
        void AddCode(AccesCode accesCode);
        void DeleteCode(AccesCode accesCode);
        Task<AccesCode> GetCode(int code);
        Task<bool> SaveAllAsync();
    }
}
