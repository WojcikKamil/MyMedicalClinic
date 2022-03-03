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
    public class PrescriptionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;  
        private readonly IMapper _mapper;
        public PrescriptionController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[Authorize(Policy = "RequireDoctorRole")]
        //[HttpGet("Active-Requests")]
        //public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetPrescriptionRequest()
        //{
        //    var currentUserEmail = User.GetUserName();

        //    return Ok(await _unitOfWork.PrescriptionRepository.GetActivePrescriptions(currentUserEmail));
        //}

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpGet("Active-RequestsV1")]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetPrescriptionRequestV1()
        {
            var currentUserEmail = User.GetUserName();

            var spec = await _unitOfWork.UserRepository.GetUserByEmail(currentUserEmail);

            return Ok(await _unitOfWork.PrescriptionRepository.GetActivePrescriptionsV1(currentUserEmail, spec.Specialization));
        }

        [HttpGet("Confirmed-Requests")]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetConfirmedPrescriptionRequest()
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.PrescriptionRepository.GetConfirmedPrescriptions(currentUserEmail));
        }

        [HttpGet("Rejected-Requests")]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetRejectedPrescriptionRequest()
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.PrescriptionRepository.GetRejectedPrescriptions(currentUserEmail));
        }

        [HttpGet("Request-History")]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetPatientHistoryRequest()
        {
            var currentUserEmail = User.GetUserName();

            return Ok(await _unitOfWork.PrescriptionRepository.GetRequestHistory(currentUserEmail));
        }

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpGet("{UserName}", Name = "WrittenOutMedicine")]
        public async Task<ActionResult<PrescriptionDTO>> GetPatientWrittenOutMedicines(string userName)
        {
            return Ok(await _unitOfWork.PrescriptionRepository.GetPatientsWrittenOutMedicines(userName));
        }

        [HttpGet("{id:int}", Name = "GetOnePrescription")]
        public async Task<ActionResult<PrescriptionDTO>> GetOnePrescription(int id)
        {
            return await _unitOfWork.PrescriptionRepository.GetPrescription(id);
        }

        [HttpPost]
        public async Task<ActionResult<PrescriptionDTO>> CreateRequestForPrescription
            (CreatePrescriptionRequestDTO createPrescriptionRequestDTO)
        {
            var email = User.GetUserName();

            var patient = await _unitOfWork.UserRepository.GetUserByEmail(email);

            var doctor = await _unitOfWork.UserRepository.GetUserByEmail(createPrescriptionRequestDTO.DoctorUserName);

            if (patient == null) return NotFound();

            if (patient == doctor) return BadRequest("Are u kidding me?");

            var prescription = new Prescription
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
                Medicines = createPrescriptionRequestDTO.Medicines,
                Dose = createPrescriptionRequestDTO.Dose,
                Content = createPrescriptionRequestDTO.Content,
                Status = "Waiting",
            };

            _unitOfWork.PrescriptionRepository.AddPrescription(prescription);

            if (await _unitOfWork.Complete())
                return Ok(_mapper.Map<PrescriptionDTO>(prescription));

            return BadRequest("Failed to request for Prescription");
        }

        [HttpPost("v1")]
        public async Task<ActionResult<PrescriptionDTO>> CreateRequestForPrescriptionv1
           (CreatePrescriptionRequestDTO createPrescriptionRequestDTO)
        {
            var email = User.GetUserName();

            var patient = await _unitOfWork.UserRepository.GetUserByEmail(email);

            var prescription = new Prescription
            {
                Patient = patient,
                PatientEmail = patient.UserName,
                PatientName = patient.Name,
                PatientLastName = patient.LastName,
                PatientPesel = patient.PESEL,
                Specialization = createPrescriptionRequestDTO.Specialization,
                Medicines = createPrescriptionRequestDTO.Medicines,
                Dose = createPrescriptionRequestDTO.Dose,
                Content = createPrescriptionRequestDTO.Content,
                Status = "Waiting",
            };

            _unitOfWork.PrescriptionRepository.AddPrescription(prescription);

            if (await _unitOfWork.Complete())
                return Ok(_mapper.Map<PrescriptionDTO>(prescription));

            return BadRequest("Failed to request for Prescription");
        }

        //[Authorize(Policy = "RequireDoctorRole")]
        //[HttpPut("Update-Prescription-Status")]
        //public async Task<ActionResult> UpdatePrescriptionStatus(PrescriptionStatusDTO prescriptionStatusDTO)
        //{
        //    var presc = await _unitOfWork.PrescriptionRepository.GetPrescriptionByID(prescriptionStatusDTO.Id);

        //    _mapper.Map(prescriptionStatusDTO, presc);
        //    _unitOfWork.PrescriptionRepository.Update(presc);

        //    if (await _unitOfWork.Complete()) return NoContent();

        //    return BadRequest("Failed");
        //}

        [Authorize(Policy = "RequireDoctorRole")]
        [HttpPut("Update-Prescription-StatusV1")]
        public async Task<ActionResult> UpdatePrescriptionStatusV1(PrescriptionStatusV1DTO prescriptionStatusV1DTO)
        {
            var presc = await _unitOfWork.PrescriptionRepository.GetPrescriptionByID(prescriptionStatusV1DTO.Id);

            _mapper.Map(prescriptionStatusV1DTO, presc);

            _unitOfWork.PrescriptionRepository.Update(presc);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed");
        }
    }
}
