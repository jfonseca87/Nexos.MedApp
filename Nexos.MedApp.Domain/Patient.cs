using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexos.MedApp.Domain
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string SocialSecurityNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [NotMapped]
        public string Doctores { get; set; }

        public ICollection<PatientDoctor> PatientDoctors { get; set; }
    }
}
