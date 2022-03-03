using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Helpers
{
    public class MessageParams : UserParams
    {
        public string UserName { get; set; }
        public string Container { get; set; } = "Unread";
    }
}
