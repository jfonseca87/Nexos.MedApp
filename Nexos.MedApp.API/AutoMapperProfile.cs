using AutoMapper;
using Nexos.MedApp.API.Models.DTOs;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<PatientDoctorDTO, PatientDoctor>();
        }
    }
}
