using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Repository.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Doctor>> GetDoctorByPatient(int idPatient);
        Task<Doctor> CreateDoctor(Doctor doctor);
    }
}
