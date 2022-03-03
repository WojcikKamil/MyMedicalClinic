using AutoMapper;
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
    public class AppointmentController : BaseApiController
    {
    
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
        
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpPost]
        public async Task<ActionResult<AppointmentDTO>> CreateAppoinment
          (CreateAppointmentDTO createAppointmentDTO)
        {
            var email = User.GetUserName();

            var doctor = await _unitOfWork.UserRepository.GetUserByEmail(email);

            var patient = await _unitOfWork.UserRepository.GetUserByEmail(createAppointmentDTO.PatientUserName);

            if (doctor == null) return NotFound();

            if (doctor == patient) return BadRequest("Are u kidding me?");

            var appointment = new Appointment
            {
                Patient = patient,
                PatientEmail = patient.UserName,
                PatientName = patient.Name,
                PatientLastName = patient.LastName,
                PatientPesel = patient.PESEL,
                DoctorEmail = doctor.UserName,
                Doctor = doctor,
                DoctorName = doctor.Name,
                DoctorLastName = doctor.LastName,
                DoctorSpecialization = doctor.Specialization,
                Reason = createAppointmentDTO.Reason,
                Diagnosis = createAppointmentDTO.Diagnosis,
                Recommendation = createAppointmentDTO.Recommendation,
                Medicines = createAppointmentDTO.Medicines,
                Dose = createAppointmentDTO.Dose,
                RecommendedDose = createAppointmentDTO.RecommendedDose,
            };

            _unitOfWork.AppointmentRepository.AddAppointment(appointment);

            if (await _unitOfWork.Complete())
                return Ok(_mapper.Map<AppointmentDTO>(appointment));

            return BadRequest("Failed to add Appointment :(");
        }

        [HttpGet("{UserName}")]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetSymptomRequest(string userName)
        {
            return Ok(await _unitOfWork.AppointmentRepository.GetAppointments(userName));
        }

        [HttpGet("{id:int}", Name = "GetAppointment")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointment(int id)
        {
            return await _unitOfWork.AppointmentRepository.GetAppintment(id);
        }
    }
}
