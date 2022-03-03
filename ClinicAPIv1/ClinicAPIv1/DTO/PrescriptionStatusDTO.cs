using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.DTO
{
    public class PrescriptionStatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime PrescriptionAccepted { get; set; } = DateTime.Now;
    }
}
