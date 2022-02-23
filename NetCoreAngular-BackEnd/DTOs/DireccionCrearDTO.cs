using System.ComponentModel.DataAnnotations;

namespace NetCoreAngular_BackEnd.DTOs
{
    public class DireccionCrearDTO
    {
        [Required]
        public string Region { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Distrito { get; set; }
        [Required]
        public string DireccionDetallada { get; set; }
    }
}
