using System;

namespace Nexos.MedApp.Domain
{
    public class PatientDoctor
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
