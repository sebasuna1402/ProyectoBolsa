using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumenPersonal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadesTecnicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadesTecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormacionAcademica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AñosEstudio = table.Column<int>(type: "int", nullable: false),
                    FechaFinalizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacionAcademica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormacionAcademica_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntradaHabilidadCa",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    HabilidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaHabilidadCa", x => new { x.CandidatoId, x.HabilidadId });
                    table.ForeignKey(
                        name: "FK_EntradaHabilidadCa_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaHabilidadCa_HabilidadesTecnicas_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "HabilidadesTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntradaOfeHab",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "int", nullable: false),
                    HabilidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaOfeHab", x => new { x.OfertaId, x.HabilidadId });
                    table.ForeignKey(
                        name: "FK_EntradaOfeHab_HabilidadesTecnicas_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "HabilidadesTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaOfeHab_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntradaOferCa",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaOferCa", x => new { x.CandidatoId, x.OfertaId });
                    table.ForeignKey(
                        name: "FK_EntradaOferCa_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaOferCa_Oferta_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaHabilidadCa_HabilidadId",
                table: "EntradaHabilidadCa",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaOfeHab_HabilidadId",
                table: "EntradaOfeHab",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_FormacionAcademica_CandidatoId",
                table: "FormacionAcademica",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_EmpresaId",
                table: "Oferta",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaHabilidadCa");

            migrationBuilder.DropTable(
                name: "EntradaOfeHab");

            migrationBuilder.DropTable(
                name: "EntradaOferCa");

            migrationBuilder.DropTable(
                name: "FormacionAcademica");

            migrationBuilder.DropTable(
                name: "HabilidadesTecnicas");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
