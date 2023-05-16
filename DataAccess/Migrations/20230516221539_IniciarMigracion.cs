using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IniciarMigracion : Migration
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
                name: "HabilidadCandidato",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    HabilidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadCandidato", x => new { x.CandidatoId, x.HabilidadId });
                    table.ForeignKey(
                        name: "FK_HabilidadCandidato_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadCandidato_HabilidadesTecnicas_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "HabilidadesTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadOferta",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "int", nullable: false),
                    HabilidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadOferta", x => new { x.OfertaId, x.HabilidadId });
                    table.ForeignKey(
                        name: "FK_HabilidadOferta_HabilidadesTecnicas_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "HabilidadesTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadOferta_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaCandidato",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaCandidato", x => new { x.CandidatoId, x.OfertaId });
                    table.ForeignKey(
                        name: "FK_OfertaCandidato_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaCandidato_Oferta_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormacionAcademica_CandidatoId",
                table: "FormacionAcademica",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadCandidato_HabilidadId",
                table: "HabilidadCandidato",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadOferta_HabilidadId",
                table: "HabilidadOferta",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_EmpresaId",
                table: "Oferta",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormacionAcademica");

            migrationBuilder.DropTable(
                name: "HabilidadCandidato");

            migrationBuilder.DropTable(
                name: "HabilidadOferta");

            migrationBuilder.DropTable(
                name: "OfertaCandidato");

            migrationBuilder.DropTable(
                name: "HabilidadesTecnicas");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
