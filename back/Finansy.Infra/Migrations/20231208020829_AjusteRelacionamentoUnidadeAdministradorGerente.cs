using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansy.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoUnidadeAdministradorGerente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Gerentes_GerenteId",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Unidades_GerenteId",
                table: "Unidades");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Unidades",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Unidades",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Unidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeId",
                table: "Gerentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_AdministradorId",
                table: "Unidades",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerentes_UnidadeId",
                table: "Gerentes",
                column: "UnidadeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gerentes_Unidades_UnidadeId",
                table: "Gerentes",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Administradores_AdministradorId",
                table: "Unidades",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gerentes_Unidades_UnidadeId",
                table: "Gerentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Administradores_AdministradorId",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Unidades_AdministradorId",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Gerentes_UnidadeId",
                table: "Gerentes");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "UnidadeId",
                table: "Gerentes");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Unidades",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Unidades",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_GerenteId",
                table: "Unidades",
                column: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Gerentes_GerenteId",
                table: "Unidades",
                column: "GerenteId",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
