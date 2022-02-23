using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAngular_BackEnd.Migrations
{
    public partial class Personas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionDetallada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.IdDireccion);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    apellidoMaterno = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.idPersona);
                });

            migrationBuilder.CreateTable(
                name: "PersonaDireccion",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    DireccionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDireccion", x => new { x.PersonaID, x.DireccionID });
                    table.ForeignKey(
                        name: "FK_PersonaDireccion_Direcciones_DireccionID",
                        column: x => x.DireccionID,
                        principalTable: "Direcciones",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaDireccion_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaDireccion_DireccionID",
                table: "PersonaDireccion",
                column: "DireccionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaDireccion");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
