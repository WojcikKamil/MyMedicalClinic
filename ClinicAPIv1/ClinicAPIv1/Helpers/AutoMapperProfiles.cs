using AutoMapper;
using ClinicAPIv1.DTO;
using ClinicAPIv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPIv1.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClinicUser, MemberDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(
                    src => src.Photos.FirstOrDefault().Url));
            CreateMap<Photo, PhotoDTO>();
            CreateMap<PatientCardDTO, ClinicUser>();
            CreateMap<DoctorUpdateDTO, ClinicUser>();
            CreateMap<TemporaryRoleUpdateDTO, ClinicUser>();
            CreateMap<RegisterDTO, ClinicUser>();
            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<PrescriptionStatusDTO, Prescription>();
            CreateMap<PrescriptionStatusV1DTO, Prescription>();
            CreateMap<Symptom, SymptomDTO>();
            CreateMap<AccesCode, CreateAccesCodeDTO>();
            CreateMap<SymptomDoctorAnswerDTO, Symptom>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<MedicalHistory, MedicalHistoryUpdateDTO>();
            CreateMap<Message, MessageDTO>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => 
                src.Sender.Photos.FirstOrDefault().Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                src.Recipient.Photos.FirstOrDefault().Url));
        }
    }
}
