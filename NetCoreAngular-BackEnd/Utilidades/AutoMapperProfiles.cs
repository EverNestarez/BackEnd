using AutoMapper;
using NetCoreAngular_BackEnd.DTOs;
using NetCoreAngular_BackEnd.Entidades;

namespace NetCoreAngular_BackEnd.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            CreateMap<PersonaCrearDTO, Persona>();

            CreateMap<Direccion, DireccionDTO>().ReverseMap();
            CreateMap<DireccionCrearDTO, Direccion>();
        }
    }
}
