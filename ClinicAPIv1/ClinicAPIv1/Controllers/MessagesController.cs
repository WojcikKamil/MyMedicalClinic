using AutoMapper;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Helpers;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    [Authorize(Policy = "RequireDoctorRole")]
    public class MessagesController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessagesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<MessageDTO>> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var email = User.GetUserName();

            if (email == createMessageDTO.RecipientUserName.ToLower())
                return BadRequest("Cannot send messages to yourself");

            var sender = await _unitOfWork.UserRepository.GetUserByEmail(email);
            var recipient = await _unitOfWork.UserRepository.GetUserByEmail(createMessageDTO.RecipientUserName);

            if (recipient == null) return NotFound();

            var message = new Message
            {
                Sender = sender,
                SenderName = sender.Name,
                SenderLastName = sender.LastName,
                Recipient = recipient,
                SenderUserName = sender.UserName,
                RecipientUserName = recipient.UserName,
                Content = createMessageDTO.Content
            };

            _unitOfWork.MessageRepository.AddMessage(message);

            if (await _unitOfWork.Complete())
                return Ok(_mapper.Map<MessageDTO>(message));

            return BadRequest("Failed to send message");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessagesForUser(
            [FromQuery] MessageParams messageParams)
        {
            messageParams.UserName = User.GetUserName();
            var messages = await _unitOfWork.MessageRepository.GetMessagesForUser(messageParams);
            Response.AddPagination(messages.CurrentPage, messages.PageSize,
                messages.TotalCount, messages.TotalPages);

            return messages;
        }

        [HttpGet("Messages")]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessages()
        {
            var email = User.GetUserName();

            return Ok(await _unitOfWork.MessageRepository.GetMessages(email));
        }

        [HttpGet("thread/{email}")]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessageThread(string email)
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.MessageRepository.GetMessageThead(currentUserEmail, email));
        }
    }
}
