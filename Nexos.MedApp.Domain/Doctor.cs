using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nexos.MedApp.Domain
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        public string CredentialNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string HospitalName { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<PatientDoctor> PatientDoctors { get; set; }
    }
}
