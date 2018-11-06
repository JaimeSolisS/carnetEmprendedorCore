using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarnetEmprendedor.Data.Migrations
{
    public partial class AddUsuarioToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Materia_MateriaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MateriaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApellidoM",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApellidoP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Semestre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    ApellidoP = table.Column<string>(nullable: true),
                    ApellidoM = table.Column<string>(nullable: true),
                    MateriaId = table.Column<int>(nullable: false),
                    Semestre = table.Column<string>(nullable: true),
                    Puntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_MateriaId",
                table: "Usuario",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoM",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoP",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Semestre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MateriaId",
                table: "AspNetUsers",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Materia_MateriaId",
                table: "AspNetUsers",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
