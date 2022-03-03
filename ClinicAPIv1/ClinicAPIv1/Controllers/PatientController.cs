using AutoMapper;
using ClinicAPIv1.Data;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    public class PatientController : BaseApiController
    {
        private readonly UserManager<ClinicUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public PatientController(UserManager<ClinicUser> userManager, 
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetPatients")]
        public async Task<ActionResult<IEnumerable>> GetPatients()
        {
            var users = await _userManager.GetUsersInRoleAsync("Patient");
            return Ok(users);
        }

        [Authorize]
        [HttpGet("PatientEmail/{userName}", Name = "GetPatientByEmail")]
        public async Task<ActionResult<MemberDTO>> PatientByEmail(string userName)
        {
            return await _unitOfWork.UserRepository.PatientByEmail(userName);
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetPatient")]
        public async Task<ActionResult<MemberDTO>> GetPatient(int id)
        {
            return await _unitOfWork.UserRepository.GetPatient(id);
        }

        [Authorize]
        [HttpPut("add-patient-card")]
        public async Task<ActionResult> AddPatientCard(PatientCardDTO patientCardDTO)
        {
            var email = User.GetUserName();
            var user = await _unitOfWork.UserRepository.GetPatientByEmail(email);

            _mapper.Map(patientCardDTO, user);
            _unitOfWork.UserRepository.Update(user);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update Patient Card");
        }
    }
}
