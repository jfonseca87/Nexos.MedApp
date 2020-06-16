using System.ComponentModel.DataAnnotations;

namespace Nexos.MedApp.API.Models.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la credencial médica")]
        public string CredentialNumber { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del doctor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del hospital")]
        public string HospitalName { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email vàlido")]
        public string Email { get; set; }
    }
}
