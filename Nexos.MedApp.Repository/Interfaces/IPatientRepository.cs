using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Repository.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Patient>> GetPatientsByDoctor(int idDoctor);
        Task<Patient> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(Patient patient);
    }
}
