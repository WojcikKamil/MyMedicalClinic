using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Helpers;
using ClinicAPIv1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public MessageRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<MessageDTO>> GetMessages(string userName)
        {
            var messages = await _context.Messages
                .OrderByDescending(m => m.MessageSent)
                .Where(u => u.Recipient.UserName == userName)
                .ToListAsync();

            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public async Task<PagedList<MessageDTO>> GetMessagesForUser(MessageParams messageParams)
        {
            var query = _context.Messages
                .OrderByDescending(m => m.MessageSent)
                .Where(u => u.Recipient.UserName == messageParams.UserName)
                .AsQueryable();

            var messages = query.ProjectTo<MessageDTO>(_mapper.ConfigurationProvider);
            return await PagedList<MessageDTO>.Create(messages, messageParams.PageNumber,
                messageParams.PageSize);
        }

        public async Task<IEnumerable<MessageDTO>> GetMessageThead(string currentUserEmail, 
            string recipientUserEmail)
        {
            //Get the all messages from users
            var messages = await _context.Messages
                .Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(m => m.Recipient.UserName == currentUserEmail
                && m.Sender.UserName == recipientUserEmail
                || m.Recipient.UserName == recipientUserEmail
                && m.Sender.UserName == currentUserEmail
                )
                .OrderBy(m => m.MessageSent)
                .ToListAsync();

            //Check if is unread messages for current user
            var unreadMessages = messages.Where(m => m.DateRead == null
            && m.Recipient.UserName == currentUserEmail).ToList();

            if (unreadMessages.Any())
            {
                foreach(var message in unreadMessages)
                {
                    message.DateRead = DateTime.Now;
                }

                await _context.SaveChangesAsync();
            }

            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
    }
}
