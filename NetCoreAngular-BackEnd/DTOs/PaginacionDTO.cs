namespace NetCoreAngular_BackEnd.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;

        private int recordsPorPagina = 10;

        private readonly int maximoRecordsPorPagina = 50;

        public int RecordsPorPagina
        {
            get { return recordsPorPagina; }
            set { recordsPorPagina = (value > maximoRecordsPorPagina) ? maximoRecordsPorPagina : value; }
        }
    }
}
