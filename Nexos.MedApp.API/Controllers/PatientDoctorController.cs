using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nexos.MedApp.API.Models;
using Nexos.MedApp.API.Models.DTOs;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Service.Interfaces;

namespace Nexos.MedApp.API.Controllers
{
    [ApiController]
    [Route("api/PatientDoctor")]
    public class PatientDoctorController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPatientDoctorsService patientDoctorsService;

        public PatientDoctorController(IMapper _mapper, IPatientDoctorsService _patientDoctorsService)
        {
            mapper = _mapper;
            patientDoctorsService = _patientDoctorsService;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateDoctor(PatientDoctorDTO patientDoctor)
        {
            ResponseModel response;

            try
            {
                var record = mapper.Map<PatientDoctor>(patientDoctor);
                await patientDoctorsService.CreatePatientDoctor(record);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.Created,
                    Response = "El registro fue creado con exito"
                };
            }
            catch (Exception ex)
            {
                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = ex.Message
                };
            }

            return response;
        }
    }
}
