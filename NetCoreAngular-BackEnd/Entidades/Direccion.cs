using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAngular_BackEnd.Entidades
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Distrito { get; set; }
        [Required]
        public string DireccionDetallada { get; set; }
        public List<PersonaDireccion> PersonaDirecciones { get; set; }
    }
}
