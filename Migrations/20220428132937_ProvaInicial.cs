using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ProvaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    downloadlink = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.downloadlink);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(15)", nullable: false),
                    password = table.Column<string>(type: "varchar(20)", nullable: false),
                    email = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Maps_Info",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(10)", nullable: false),
                    title = table.Column<string>(type: "varchar(40)", nullable: false),
                    description = table.Column<string>(type: "varchar(300)", nullable: true),
                    icon = table.Column<byte[]>(type: "bytea", nullable: false),
                    authorusername = table.Column<string>(type: "varchar(15)", nullable: false),
                    mapdownloadlink = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_Maps_Info_Map_mapdownloadlink",
                        column: x => x.mapdownloadlink,
                        principalTable: "Map",
                        principalColumn: "downloadlink");
                    table.ForeignKey(
                        name: "FK_Maps_Info_Players_authorusername",
                        column: x => x.authorusername,
                        principalTable: "Players",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_Info_authorusername",
                table: "Maps_Info",
                column: "authorusername");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_Info_mapdownloadlink",
                table: "Maps_Info",
                column: "mapdownloadlink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maps_Info");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
