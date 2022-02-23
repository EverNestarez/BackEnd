namespace NetCoreAngular_BackEnd.Entidades
{
    public class PersonaDireccion
    {
        public int PersonaID { get; set; }
        public int DireccionID { get; set; }
        public Persona Persona { get; set; }
        public Direccion Direccion { get; set; }

    }
}
