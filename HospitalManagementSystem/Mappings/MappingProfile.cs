using AutoMapper;
using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Examination, ExaminationDto>().ReverseMap();
            CreateMap<MedicalSpecialty, MedicalSpecialtyDto>().ReverseMap();
        }
    }

}
