using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuidarDePerto.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CDP_IDOSO",
                columns: table => new
                {
                    ID_IDOSO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_IDOSO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NR_IDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_ENDERECO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CDP_IDOSO", x => x.ID_IDOSO);
                });

            migrationBuilder.CreateTable(
                name: "T_CDP_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_ALERTA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DT_ALERTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_IDOSO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CDP_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_T_CDP_ALERTA_T_CDP_IDOSO_ID_IDOSO",
                        column: x => x.ID_IDOSO,
                        principalTable: "T_CDP_IDOSO",
                        principalColumn: "ID_IDOSO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CDP_ALERTA_ID_IDOSO",
                table: "T_CDP_ALERTA",
                column: "ID_IDOSO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CDP_ALERTA");

            migrationBuilder.DropTable(
                name: "T_CDP_IDOSO");
        }
    }
}
