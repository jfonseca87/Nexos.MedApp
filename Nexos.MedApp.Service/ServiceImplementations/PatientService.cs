using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Repository.Interfaces;
using Nexos.MedApp.Service.Interfaces;

namespace Nexos.MedApp.Service.ServiceImplementations
{
    public class PatientService : IPatientService
    {
        public readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository _patientRepository)
        {
            patientRepository = _patientRepository;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            return await patientRepository.CreatePatient(patient);
        }

        public async Task DeletePatient(int id)
        {
            Patient patientDelete = await patientRepository.GetPatient(id);

            if (patientDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            await patientRepository.DeletePatient(patientDelete);
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await patientRepository.GetPatient(id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await patientRepository.GetPatients();
        }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctor(int idDoctor)
        {
            return await patientRepository.GetPatientsByDoctor(idDoctor);
        }

        public async Task UpdatePatient(Patient patient)
        {
            Patient patientUpdate = await patientRepository.GetPatient(patient.PatientId);

            if (patientUpdate == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            patientUpdate.SocialSecurityNumber = patient.SocialSecurityNumber;
            patientUpdate.Name = patient.Name;
            patientUpdate.ZipCode = patient.ZipCode;
            patientUpdate.Address = patient.Address;
            patientUpdate.PhoneNumber = patient.PhoneNumber;
            patientUpdate.Email = patient.Email;

            await patientRepository.UpdatePatient(patientUpdate);
        }
    }
}
