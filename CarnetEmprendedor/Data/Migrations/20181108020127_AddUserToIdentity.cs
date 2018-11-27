using Microsoft.EntityFrameworkCore.Migrations;

namespace CarnetEmprendedor.Data.Migrations
{
    public partial class AddUserToIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Usuario",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserName",
                table: "Usuario",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdentityUserId",
                table: "Usuario",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_AspNetUsers_IdentityUserId",
                table: "Usuario",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_AspNetUsers_IdentityUserId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdentityUserId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdentityUserName",
                table: "Usuario");
        }
    }
}
