using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nexos.MedApp.Domain;
using Nexos.MedApp.Repository.Interfaces;

namespace Nexos.MedApp.Repository.SQLImplementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedContext db;

        public DoctorRepository(MedContext _db)
        {
            db = _db;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            doctor.CreationDate = DateTime.Now;

            await db.Doctors.AddAsync(doctor);
            await db.SaveChangesAsync();

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorByPatient(int idPatient)
        {
            var doctors = await (from d in db.Doctors
                           join pd in db.PatientDoctors
                           on d.DoctorId equals pd.DoctorId into tempDoctors
                           from temp in tempDoctors.DefaultIfEmpty()
                           where temp.PatientId == idPatient
                           select d).ToListAsync();

            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await db.Doctors.Include(x => x.PatientDoctors).ToListAsync();
            return doctors;
        }
    }
}
