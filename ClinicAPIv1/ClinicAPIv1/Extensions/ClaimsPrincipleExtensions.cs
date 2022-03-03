using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClinicAPIv1.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUserName(this ClaimsPrincipal userName)
        {
            return userName.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
