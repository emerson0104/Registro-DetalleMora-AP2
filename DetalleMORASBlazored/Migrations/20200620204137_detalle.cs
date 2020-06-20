using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DetalleMORASBlazored.Migrations
{
    public partial class detalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moras",
                columns: table => new
                {
                    MoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.MoraId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PersonaId = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 40, nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                });

            migrationBuilder.CreateTable(
                name: "MoraDetalle",
                columns: table => new
                {
                    MoraDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoraId = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraDetalle", x => x.MoraDetalleId);
                    table.ForeignKey(
                        name: "FK_MoraDetalle_Moras_MoraId",
                        column: x => x.MoraId,
                        principalTable: "Moras",
                        principalColumn: "MoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoraDetalle_MoraId",
                table: "MoraDetalle",
                column: "MoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoraDetalle");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Moras");
        }
    }
}
