using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Nexos.MedApp.Domain;

namespace Nexos.MedApp.Repository.SQLImplementation
{
    public class MedContext : DbContext
    {
        public MedContext(DbContextOptions<MedContext> options) 
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientDoctor> PatientDoctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDoctor>()
            .HasKey(x => new { x.PatientId, x.DoctorId });

            modelBuilder.Entity<PatientDoctor>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.PatientDoctors)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PatientDoctor>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.PatientDoctors)
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
