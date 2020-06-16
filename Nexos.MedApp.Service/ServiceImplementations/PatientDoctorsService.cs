using System.Threading.Tasks;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Repository.Interfaces;
using Nexos.MedApp.Service.Interfaces;

namespace Nexos.MedApp.Service.ServiceImplementations
{
    public class PatientDoctorsService : IPatientDoctorsService
    {
        private readonly IPatientDoctorsRepository patientDoctorsRepository;

        public PatientDoctorsService(IPatientDoctorsRepository _patientDoctorsRepository)
        {
            patientDoctorsRepository = _patientDoctorsRepository;
        }

        public async Task CreatePatientDoctor(PatientDoctor patientDoctor)
        {
            await patientDoctorsRepository.CreatePatientDoctor(patientDoctor);
        }
    }
}
