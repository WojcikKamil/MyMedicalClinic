using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Extensions
{
    public static class SeniorityTimeExtensions
    {
        public static int CalculateSeniority(this DateTime dob)
        {
            var today = DateTime.Today;
            var seniority = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-seniority)) seniority--;
            return seniority;
        }
    }
}
