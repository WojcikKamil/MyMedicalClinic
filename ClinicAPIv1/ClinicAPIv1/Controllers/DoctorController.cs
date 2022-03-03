using AutoMapper;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Helpers;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ClinicUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public DoctorController(IUnitOfWork unitOfWork,
            IMapper mapper, UserManager<ClinicUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetDoctors")]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetDoctors
            ([FromQuery] UserParams userParams, [FromQuery] FilteringProperties filter)
        {
            var users = await _unitOfWork.UserRepository.GetDoctors(userParams, filter);

            Response.AddPagination(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [HttpGet("GetDoctorsV1")]
        public async Task<ActionResult> GetDoctorsV1()
        {
            var users = await _userManager.GetUsersInRoleAsync("Doctor");

            return Ok(users);
        }

        [HttpGet("{id:int}", Name = "GetDoctor")]
        public async Task<ActionResult<MemberDTO>> GetDoctor(int id)
        {
            return await _unitOfWork.UserRepository.GetDoctor(id);
        }

        [HttpGet("{UserName}", Name = "GetDoctorByEmail")]
        public async Task<ActionResult<MemberDTO>> GetDoctorByEmail(string userName)
        {
            return await _unitOfWork.UserRepository.GetMemberByEmail(userName);
        }

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(DoctorUpdateDTO doctorUpdateDTO)
        {
            var email = User.GetUserName(); //should give a email from the token
            var user = await _unitOfWork.UserRepository.GetDoctorByEmail(email);

            _mapper.Map(doctorUpdateDTO, user);

            _unitOfWork.UserRepository.Update(user);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update Doctor Profile");
        }
    }
}
