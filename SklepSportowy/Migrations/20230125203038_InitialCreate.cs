using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SklepSportowy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SprzetSportowy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSprzetu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelSprzetu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprzetSportowy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DzienDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SprzetId = table.Column<int>(type: "int", nullable: false),
                    SprzetSportowyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaId);
                    table.ForeignKey(
                        name: "FK_Firma_SprzetSportowy_SprzetSportowyId",
                        column: x => x.SprzetSportowyId,
                        principalTable: "SprzetSportowy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Promocja",
                columns: table => new
                {
                    PromocjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaPromocji = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WartoscPromocji = table.Column<int>(type: "int", nullable: false),
                    SprzetId = table.Column<int>(type: "int", nullable: false),
                    SprzetSportowyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocja", x => x.PromocjaId);
                    table.ForeignKey(
                        name: "FK_Promocja_SprzetSportowy_SprzetSportowyId",
                        column: x => x.SprzetSportowyId,
                        principalTable: "SprzetSportowy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firma_SprzetSportowyId",
                table: "Firma",
                column: "SprzetSportowyId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocja_SprzetSportowyId",
                table: "Promocja",
                column: "SprzetSportowyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropTable(
                name: "Promocja");

            migrationBuilder.DropTable(
                name: "SprzetSportowy");
        }
    }
}
