using NetCoreAngular_BackEnd.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAngular_BackEnd.DTOs
{
    public class PersonaCrearDTO
    {
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [StringLength(maximumLength: 50)]
        [primeraLetraMayuscula]
        public string nombres { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [StringLength(maximumLength: 40)]
        public string apellidoPaterno { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [StringLength(maximumLength: 40)]
        public string apellidoMaterno { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [Range(18, 120)]
        public int edad { get; set; }
    }
}
