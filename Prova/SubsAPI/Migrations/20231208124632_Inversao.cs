using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubsAPI.Migrations
{
    public partial class Inversao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_IMCs_IMCId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_IMCId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "IMCId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "IMCs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IMCs_AlunoId",
                table: "IMCs",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_IMCs_Alunos_AlunoId",
                table: "IMCs",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMCs_Alunos_AlunoId",
                table: "IMCs");

            migrationBuilder.DropIndex(
                name: "IX_IMCs_AlunoId",
                table: "IMCs");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "IMCs");

            migrationBuilder.AddColumn<int>(
                name: "IMCId",
                table: "Alunos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IMCId",
                table: "Alunos",
                column: "IMCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_IMCs_IMCId",
                table: "Alunos",
                column: "IMCId",
                principalTable: "IMCs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
