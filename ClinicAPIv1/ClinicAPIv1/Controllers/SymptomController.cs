using AutoMapper;
using ClinicAPIv1.Data;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
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
    [Authorize]
    public class SymptomController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public SymptomController(IUnitOfWork unitOfWork,
            IMapper mapper, DataContext context
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpGet("Active-Requests")]
        public async Task<ActionResult<IEnumerable<SymptomDTO>>> GetSymptomRequest()
        {
            var currentUserEmail = User.GetUserName();

            var spec = await _unitOfWork.UserRepository.GetUserByEmail(currentUserEmail);

            return Ok(await _unitOfWork.SymptomRepository.GetActiveSymptomRequest(currentUserEmail, spec.Specialization));
        }

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpGet("RequestCount")]
        public async Task<ActionResult<IEnumerable<SymptomDTO>>> GetCount()
        {
            var currentUserEmail = User.GetUserName();

            var spec = await _unitOfWork.UserRepository.GetUserByEmail(currentUserEmail);

            var count = await _unitOfWork.SymptomRepository.GetActiveSymptomRequest(currentUserEmail, spec.Specialization);

            var num = count.Count();

            return Ok(num);
        }

        [HttpGet("Answered-Requests")]
        public async Task<ActionResult<IEnumerable<SymptomDTO>>> GetAnsweredSymptomRequest()
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.SymptomRepository.GetAnswederSymptomRequest(currentUserEmail));
        }

        [HttpGet("Request-History")]
        public async Task<ActionResult<IEnumerable<SymptomDTO>>> GetPatientSymptomHistoryRequest()
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.SymptomRepository.GetRequestHistory(currentUserEmail));
        }

        [HttpGet("Request-Answered-History")]
        public async Task<ActionResult<IEnumerable<SymptomDTO>>> GetAnsweredPatientSymptomHistoryRequest()
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.SymptomRepository.GetAnsweredRequestHistory(currentUserEmail));
        }

        [HttpGet("{id:int}", Name = "GetOneSymptomRequest")]
        public async Task<ActionResult<SymptomDTO>> GetOneSymoptom(int id)
        {
            return await _unitOfWork.SymptomRepository.GetSymptom(id);
        }

        [HttpPost]
        public async Task<ActionResult<SymptomDTO>> CreateRequestForSymptom
           (CreateSymptomRequestDTO createSymptomRequestDTO)
        {
            var email = User.GetUserName();

            var patient = await _unitOfWork.UserRepository.GetUserByEmail(email);

            if (patient == null) return NotFound();

            var symptom = new Symptom
            {
                Patient = patient,
                PatientEmail = patient.UserName,
                PatientName = patient.Name,
                PatientLastName = patient.LastName,
                PatientPesel = patient.PESEL,
                Specialization = createSymptomRequestDTO.Specialization,
                WorryingSymptom = createSymptomRequestDTO.WorryingSymptom,
                DoctorAnswer = "",
            };

            _unitOfWork.SymptomRepository.AddSymptom(symptom);

            if (await _unitOfWork.Complete())
                return Ok(_mapper.Map<SymptomDTO>(symptom));

            return BadRequest("Failed to request for Symptom");
        }

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpPut("Update-Symptom-Answer")]
        public async Task<ActionResult> UpdateSymptomAnswer(SymptomDoctorAnswerDTO symptomDoctorAnswerDTO)
        {
            var symp = await _unitOfWork.SymptomRepository.GetSymptomById(symptomDoctorAnswerDTO.Id);

            _mapper.Map(symptomDoctorAnswerDTO, symp);
            _unitOfWork.SymptomRepository.Update(symp);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed");

        }
    }
}
