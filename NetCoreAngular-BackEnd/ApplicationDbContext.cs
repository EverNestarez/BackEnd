using Microsoft.EntityFrameworkCore;
using NetCoreAngular_BackEnd.Entidades;

namespace NetCoreAngular_BackEnd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonaDireccion>()
                .HasKey(x => new { x.PersonaID, x.DireccionID 
                });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
    }
}
