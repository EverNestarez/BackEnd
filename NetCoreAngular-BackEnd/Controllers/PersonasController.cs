using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreAngular_BackEnd.DTOs;
using NetCoreAngular_BackEnd.Entidades;
using NetCoreAngular_BackEnd.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngular_BackEnd.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class personasController : ControllerBase
    {

        private readonly ILogger<personasController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public personasController(ILogger<
            personasController> logger,
            ApplicationDbContext context,
            IMapper mapper) 
        {

            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<List<PersonaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {

            var queryable = context.Personas.AsQueryable();

            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var personas = await queryable.OrderBy(x => x.idPersona).Paginar(paginacionDTO).ToListAsync();

            return mapper.Map<List<PersonaDTO>>(personas);
        }

        [HttpGet("Buscar/{idPersona:int}")]
        public async Task<ActionResult<PersonaDTO>> Get(int idPersona) {
            var persona = await context.Personas.FirstOrDefaultAsync(x => x.idPersona == idPersona);
            if (persona == null)
            {
                return NotFound();
            }
            return mapper.Map<PersonaDTO>(persona);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult> Post([FromBody] PersonaCrearDTO personaCrearDTO){
            var persona = mapper.Map<Persona>(personaCrearDTO);
            context.Add(persona);
            await context.SaveChangesAsync();
            return NoContent();

        }
        [HttpPut("Actualizar/{idPersona:int}")]
        public async Task<ActionResult> Put(int idPersona, [FromBody] PersonaCrearDTO personaCrearDTO) {

            var persona = await context.Personas.FirstOrDefaultAsync(x => x.idPersona == idPersona);
            if (persona == null)
            {
                return NotFound();
            }
            persona = mapper.Map(personaCrearDTO, persona);

            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("Eliminar/{idPersona:int}")]
        public async Task<ActionResult> Delete(int idPersona) {
            var existe = await context.Personas.AnyAsync(x => x.idPersona == idPersona);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Persona() { idPersona = idPersona });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
