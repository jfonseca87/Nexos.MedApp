using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.MedApp.API.Models.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nùmero de seguro social")]
        public string SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "Debe ingresar los nombres completos")]
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nùmero telefònico")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Debe ingresar in email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email vàlido")]
        public string Email { get; set; }

        public string Doctores { get; set; }
    }
}
