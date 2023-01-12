using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioApiMelao.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tarefas",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Titulo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                Descricao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                DataTarefa = table.Column<DateTime>(type: "DATETIME", nullable: false, computedColumnSql: "GetUtcDate()")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tarefas", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tarefas_Id",
            table: "Tarefas",
            column: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tarefas");
    }
}
