using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansy.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var senha =
                "$argon2id$v=19$m=32768,t=4,p=1$8kSN61J8u9f2fBanH2sbjA$mcjis6H1GOwjNVVNBznVkOkktsa+CHUc9bP95x8IsEo";
            
            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "Nome", "Email", "Senha", "Cpf", "CriadoEm", "AtualizadoEm" },
                values: new object[,]
                {
                    { 1, "Admin", "admin@admin.com", senha, "79655469069","2022-08-21 19:05:48", "2022-08-21 19:05:48"  }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .DeleteData("Administradores", "Id", 1);
        }
    }
}