using AutoMapper;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Extensions;
using ClinicAPIv1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Controllers
{
    public class MedicalHistoryController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MedicalHistoryController(IUserRepository userRepository,
            IMedicalHistoryRepository medicalHistoryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _userRepository = userRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
            _mapper = mapper;
        }

        //[Authorize]
        //[HttpPut]
        //public async Task<ActionResult> AddPatientMedicalHistory(MedicalHistoryUpdateDTO medicalHistoryUpdateDTO)
        //{
        //    //var email = User.GetUserName();
        //    //var user = await _userRepository.GetUserByEmail(email);
        //    ////var user = await _medicalHistoryRepository.GetMedicalHistoryByUserName(medicalHistoryUpdateDTO.PatientEmail);

        //    //_mapper.Map(medicalHistoryUpdateDTO, user);
        //    //_medicalHistoryRepository.Update(user);

        //    //if (await _userRepository.SaveAllAsync()) return NoContent();

        //    //return BadRequest("Failed to update Patient Card");
        //}

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<MedicalHistoryUpdateDTO>> GetOnePrescription(string userName)
        {
            return await _medicalHistoryRepository.GetMedicalHistoryv1(userName);
        }
    }
}
