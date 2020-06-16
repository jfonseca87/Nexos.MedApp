using System.Collections.Generic;
using System.Threading.Tasks;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Service.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Doctor>> GetDoctorByPatient(int idPatient);
        Task<Doctor> CreateDoctor(Doctor doctor);
    }
}
