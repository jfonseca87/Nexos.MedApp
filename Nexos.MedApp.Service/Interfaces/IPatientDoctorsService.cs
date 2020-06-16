using System.Threading.Tasks;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Service.Interfaces
{
    public interface IPatientDoctorsService
    {
        Task CreatePatientDoctor(PatientDoctor patientDoctor);
    }
}
