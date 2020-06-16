using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Repository.Interfaces;

namespace Nexos.MedApp.Repository.SQLImplementation
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedContext db;

        public PatientRepository(MedContext _db)
        {
            db = _db;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            patient.CreationDate = DateTime.Now;

            await db.Patients.AddAsync(patient);
            await db.SaveChangesAsync();

            return patient;
        }

        public  async Task DeletePatient(Patient patient)
        {
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            Patient patient = await db.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            IEnumerable<Patient> patients = await (from p in db.Patients
                                                   select new Patient
                                                   {
                                                       PatientId = p.PatientId,
                                                       SocialSecurityNumber = p.SocialSecurityNumber,
                                                       Name = p.Name,
                                                       ZipCode = p.ZipCode,
                                                       Address = p.Address,
                                                       PhoneNumber = p.PhoneNumber,
                                                       Email = p.Email,
                                                       Doctores = (string.Join(", ", from d in db.Doctors
                                                                                    join pd in db.PatientDoctors
                                                                                    on d.DoctorId equals pd.DoctorId into tempDoctors
                                                                                    from temp in tempDoctors.DefaultIfEmpty()
                                                                                    where temp.PatientId == p.PatientId
                                                                                    select d.Name))
                                                   }).ToListAsync();
            return patients;
        }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctor(int idDoctor)
        {
            var patients = await (from p in db.Patients
                                  join pd in db.PatientDoctors
                                  on p.PatientId equals pd.PatientId into tempPatients
                                  from temp in tempPatients.DefaultIfEmpty()
                                  where temp.DoctorId == idDoctor
                                  select p).ToListAsync();

            return patients;
        }

        public async Task UpdatePatient(Patient patient)
        {
            patient.UpdateDate = DateTime.Now;

            db.Entry(patient).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
