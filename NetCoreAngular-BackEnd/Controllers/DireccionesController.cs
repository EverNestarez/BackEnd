using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreAngular_BackEnd.DTOs;
using NetCoreAngular_BackEnd.Entidades;
using NetCoreAngular_BackEnd.Utilidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular_BackEnd.Controllers
{
    [Route("api/direcciones")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DireccionesController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("Listar")]
        public async Task<ActionResult<List<DireccionDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {

            var queryable = context.Direcciones.AsQueryable();

            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var direccion = await queryable.OrderBy(x => x.IdDireccion).Paginar(paginacionDTO).ToListAsync();

            return mapper.Map<List<DireccionDTO>>(direccion);
        }
        [HttpGet("Buscar/{IdDireccion:int}")]
        public async Task<ActionResult<DireccionDTO>> Get(int IdDireccion)
        {
            var direccion = await context.Direcciones.FirstOrDefaultAsync(x => x.IdDireccion == IdDireccion);
            if (direccion == null)
            {
                return NotFound();
            }
            return mapper.Map<DireccionDTO>(direccion);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult> Post([FromBody] DireccionCrearDTO direccionCrearDTO)
        {
            var direccion = mapper.Map<Direccion>(direccionCrearDTO);
            context.Add(direccion);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("Actualizar/{IdDireccion:int}")]
        public async Task<ActionResult> Put(int IdDireccion, [FromBody] DireccionCrearDTO direccionCrearDTO)
        {

            var direccion = await context.Direcciones.FirstOrDefaultAsync(x => x.IdDireccion == IdDireccion);
            if (direccion == null)
            {
                return NotFound();
            }
            direccion = mapper.Map(direccionCrearDTO, direccion);

            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("Eliminar/{IdDireccion:int}")]
        public async Task<ActionResult> Delete(int IdDireccion)
        {
            var existe = await context.Direcciones.AnyAsync(x => x.IdDireccion == IdDireccion);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Direccion() { IdDireccion = IdDireccion });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
