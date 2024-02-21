using System.ComponentModel.DataAnnotations;

namespace APIRest.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "DPI")]
        [MinLength(15, ErrorMessage = "El {0} ser mayor a 15 digitos")]
        public string dpi { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Apellidos")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesion")]
        public string Profesion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
    }
}
