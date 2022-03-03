using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderUserName { get; set; }
        public string SenderTemporaryRole { get; set; }
        public ClinicUser Sender { get; set; }
        public int RecipientID { get; set; }
        public string RecipientUserName { get; set; }
        public ClinicUser Recipient { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.Now;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}
