using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Repository.Interfaces;
using Nexos.MedApp.Service.Interfaces;

namespace Nexos.MedApp.Service.ServiceImplementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository _doctorRepository)
        {
            doctorRepository = _doctorRepository;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            return await doctorRepository.CreateDoctor(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorByPatient(int idPatient)
        {
            return await doctorRepository.GetDoctorByPatient(idPatient);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await doctorRepository.GetDoctors(); 
        }
    }
}
