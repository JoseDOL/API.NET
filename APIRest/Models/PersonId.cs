using System.ComponentModel.DataAnnotations;

namespace APIRest.Models
{
    public class PersonId
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "DPI")]
        [MinLength(15, ErrorMessage = "El {0} ser mayor a 15 digitos")]
        public String dpi { get; set; }
    }
}
