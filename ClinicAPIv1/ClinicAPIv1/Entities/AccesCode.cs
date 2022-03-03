using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Entities
{
    [Table("AccesCode")]
    public class AccesCode
    {
        public int Id { get; set; }
        public int Code { get; set; }
    }
}
