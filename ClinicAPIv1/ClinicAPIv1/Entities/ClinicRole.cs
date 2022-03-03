using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Entities
{
    public class ClinicRole : IdentityRole<int>
    {
        public ICollection<ClinicUserRole> ClinicRoles { get; set; }
    }
}
