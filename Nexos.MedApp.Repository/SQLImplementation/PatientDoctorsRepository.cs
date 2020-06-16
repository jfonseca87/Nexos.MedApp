using System;
using System.Threading.Tasks;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Repository.Interfaces;

namespace Nexos.MedApp.Repository.SQLImplementation
{
    public class PatientDoctorsRepository : IPatientDoctorsRepository
    {
        private readonly MedContext db;

        public PatientDoctorsRepository(MedContext _db)
        {
            db = _db;
        }

        public async Task CreatePatientDoctor(PatientDoctor patientDoctor)
        {
            patientDoctor.CreationDate = DateTime.Now;

            await db.PatientDoctors.AddAsync(patientDoctor);
            await db.SaveChangesAsync();
        }
    }
}
