using System.Threading.Tasks;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Repository.Interfaces
{
    public interface IPatientDoctorsRepository
    {
        Task CreatePatientDoctor(PatientDoctor patientDoctor);
    }
}
