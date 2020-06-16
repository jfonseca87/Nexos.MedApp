using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Service.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Patient>> GetPatientsByDoctor(int idDoctor);
        Task<Patient> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(int id);
    }
}
