using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookStoreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Emri",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KodiPostal",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KompaniaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qyteti",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rruga",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shteti",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Renditja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kompania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rruga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shteti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodiPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumriTelefonit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kopertina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kopertina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porosia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerdorusiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataEPorosise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEDergeses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Totali = table.Column<double>(type: "float", nullable: false),
                    StatusiIPorosise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusiIPageses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumriGjurmues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEPageses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPerPagese = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumriITelefonit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rruga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodiPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porosia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porosia_AspNetUsers_PerdorusiId",
                        column: x => x.PerdorusiId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produkti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CmimiBaze = table.Column<double>(type: "float", nullable: false),
                    Cmimi = table.Column<double>(type: "float", nullable: false),
                    Cmimi50 = table.Column<double>(type: "float", nullable: false),
                    Cmimi100 = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    KopertinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkti_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkti_Kopertina_KopertinaId",
                        column: x => x.KopertinaId,
                        principalTable: "Kopertina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetajetEPorosive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorosiaId = table.Column<int>(type: "int", nullable: false),
                    ProduktiId = table.Column<int>(type: "int", nullable: false),
                    Sasia = table.Column<double>(type: "float", nullable: false),
                    Cmimi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetajetEPorosive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetajetEPorosive_Porosia_PorosiaId",
                        column: x => x.PorosiaId,
                        principalTable: "Porosia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetajetEPorosive_Produkti_ProduktiId",
                        column: x => x.ProduktiId,
                        principalTable: "Produkti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shporta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktiId = table.Column<int>(type: "int", nullable: false),
                    Sasia = table.Column<int>(type: "int", nullable: false),
                    PerdorusiId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shporta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shporta_AspNetUsers_PerdorusiId",
                        column: x => x.PerdorusiId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shporta_Produkti_ProduktiId",
                        column: x => x.ProduktiId,
                        principalTable: "Produkti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KompaniaId",
                table: "AspNetUsers",
                column: "KompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetajetEPorosive_PorosiaId",
                table: "DetajetEPorosive",
                column: "PorosiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetajetEPorosive_ProduktiId",
                table: "DetajetEPorosive",
                column: "ProduktiId");

            migrationBuilder.CreateIndex(
                name: "IX_Porosia_PerdorusiId",
                table: "Porosia",
                column: "PerdorusiId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkti_KategoriaId",
                table: "Produkti",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkti_KopertinaId",
                table: "Produkti",
                column: "KopertinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Shporta_PerdorusiId",
                table: "Shporta",
                column: "PerdorusiId");

            migrationBuilder.CreateIndex(
                name: "IX_Shporta_ProduktiId",
                table: "Shporta",
                column: "ProduktiId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kompania_KompaniaId",
                table: "AspNetUsers",
                column: "KompaniaId",
                principalTable: "Kompania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kompania_KompaniaId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DetajetEPorosive");

            migrationBuilder.DropTable(
                name: "Kompania");

            migrationBuilder.DropTable(
                name: "Shporta");

            migrationBuilder.DropTable(
                name: "Porosia");

            migrationBuilder.DropTable(
                name: "Produkti");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Kopertina");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KompaniaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Emri",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KodiPostal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KompaniaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Qyteti",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rruga",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Shteti",
                table: "AspNetUsers");
        }
    }
}
