using Microsoft.EntityFrameworkCore.Migrations;

namespace CarnetEmprendedor.Data.Migrations
{
    public partial class AddUserInfoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
