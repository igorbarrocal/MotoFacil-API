using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoFacil_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Motos_MotoId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Usuarios_UsuarioId",
                table: "Servicos");

            migrationBuilder.AddColumn<int>(
                name: "MotoId1",
                table: "Servicos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_MotoId1",
                table: "Servicos",
                column: "MotoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Motos_MotoId",
                table: "Servicos",
                column: "MotoId",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Motos_MotoId1",
                table: "Servicos",
                column: "MotoId1",
                principalTable: "Motos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Usuarios_UsuarioId",
                table: "Servicos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Motos_MotoId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Motos_MotoId1",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Usuarios_UsuarioId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_MotoId1",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "MotoId1",
                table: "Servicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Motos_MotoId",
                table: "Servicos",
                column: "MotoId",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Usuarios_UsuarioId",
                table: "Servicos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
