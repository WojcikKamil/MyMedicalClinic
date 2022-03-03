using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Interfaces
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDTO>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDTO>> GetMessageThead(string currentUserEmail, string recipientUserEmail);
        Task<IEnumerable<MessageDTO>> GetMessages(string userName);
        
    }
}
