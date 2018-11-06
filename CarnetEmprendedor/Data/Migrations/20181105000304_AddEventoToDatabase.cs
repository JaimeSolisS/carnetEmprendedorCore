using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarnetEmprendedor.Data.Migrations
{
    public partial class AddEventoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaEventoId = table.Column<int>(nullable: false),
                    PuntosEvento = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fin = table.Column<DateTime>(nullable: false),
                    Lugar = table.Column<string>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    NumBoletos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_Categoria_CategoriaEventoId",
                        column: x => x.CategoriaEventoId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evento_CategoriaEventoId",
                table: "Evento",
                column: "CategoriaEventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evento");
        }
    }
}
