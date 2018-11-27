using Microsoft.EntityFrameworkCore.Migrations;

namespace CarnetEmprendedor.Data.Migrations
{
    public partial class AddListadoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Matricula",
                table: "ListaInteresado",
                newName: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaInteresado_UsuarioId",
                table: "ListaInteresado",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaInteresado_Usuario_UsuarioId",
                table: "ListaInteresado",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaInteresado_Usuario_UsuarioId",
                table: "ListaInteresado");

            migrationBuilder.DropIndex(
                name: "IX_ListaInteresado_UsuarioId",
                table: "ListaInteresado");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ListaInteresado",
                newName: "Matricula");
        }
    }
}
