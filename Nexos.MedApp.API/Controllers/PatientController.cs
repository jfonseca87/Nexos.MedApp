using System;
using System.Collections.Generic;
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
    [Route("api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPatientService patientService;

        public PatientController(IMapper _mapper, IPatientService _patientService)
        {
            mapper = _mapper;
            patientService = _patientService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetPatients()
        {
            ResponseModel response;

            try
            {
                var patients = await patientService.GetPatients();
                var patientsView = mapper.Map<List<PatientDTO>>(patients);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = patientsView
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

        [HttpGet("{id}")]
        public async Task<ResponseModel> GetPatient(int id)
        {
            ResponseModel response;

            try
            {
                var patient = await patientService.GetPatient(id);
                var patientView = mapper.Map<PatientDTO>(patient);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = patientView
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

        [HttpGet("patientsByDoctor/{idDoctor}")]
        public async Task<ResponseModel> GetPatientsByDoctor(int idDoctor)
        {
            ResponseModel response;

            try
            {
                var patient = await patientService.GetPatientsByDoctor(idDoctor);
                var patientsView = mapper.Map<List<PatientDTO>>(patient);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = patientsView
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
        public async Task<ResponseModel> CreatePatient(PatientDTO patientDTO)
        {
            ResponseModel response;

            try
            {
                var patient = mapper.Map<Patient>(patientDTO);
                var patientCreated = await patientService.CreatePatient(patient);
                var patientView = mapper.Map<PatientDTO>(patientCreated);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.Created,
                    Response = patientView
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

        [HttpPut]
        public async Task<ResponseModel> UpdatePatient(PatientDTO patientDTO)
        {
            ResponseModel response;

            try
            {
                var patient = mapper.Map<Patient>(patientDTO);
                await patientService.UpdatePatient(patient);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "El paciente fue actualizado con exito"
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

        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeletePatient(int id)
        {
            ResponseModel response;

            try
            {
                await patientService.DeletePatient(id);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "El paciente fue eliminado con exito"
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
