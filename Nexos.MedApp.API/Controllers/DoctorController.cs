using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nexos.MedApp.API.Models;
using Nexos.MedApp.API.Models.DTOs;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Service.Interfaces;
using Nexos.MedApp.Service.ServiceImplementations;

namespace Nexos.MedApp.API.Controllers
{
    [ApiController]
    [Route("api/Doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDoctorService doctorService;

        public DoctorController(IMapper _mapper, IDoctorService _doctorService)
        {
            mapper = _mapper;
            doctorService = _doctorService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetDoctors()
        {
            ResponseModel response;

            try
            {
                var doctors = await doctorService.GetDoctors();
                var doctorsView = mapper.Map<List<DoctorDTO>>(doctors);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = doctorsView
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

        [HttpGet("doctorsByPatient/{patientId}")]
        public async Task<ResponseModel> GetDoctorsByPatient(int patientId)
        {
            ResponseModel response;

            try
            {
                var doctors = await doctorService.GetDoctorByPatient(patientId);
                var doctorsView = mapper.Map<List<DoctorDTO>>(doctors);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = doctorsView
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

        [HttpPost]
        public async Task<ResponseModel> CreateDoctor(DoctorDTO doctorDTO)
        {
            ResponseModel response;

            try
            {
                var doctor = mapper.Map<Doctor>(doctorDTO);
                var doctorCreated = await doctorService.CreateDoctor(doctor);
                var doctorView = mapper.Map<DoctorDTO>(doctorCreated);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.Created,
                    Response = doctorView
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
