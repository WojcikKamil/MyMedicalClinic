using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Entities
{
    public class ClinicUserRole : IdentityUserRole<int>
    {
        public ClinicUser User { get; set; }
        public ClinicRole Role { get; set; }
    }
}
