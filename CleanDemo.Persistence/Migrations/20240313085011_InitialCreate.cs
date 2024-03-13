using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanDemo.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Births",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Births", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deaths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deaths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marriages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WifeId = table.Column<int>(type: "int", nullable: false),
                    HusbandId = table.Column<int>(type: "int", nullable: false),
                    MarriageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marriages_Births_HusbandId",
                        column: x => x.HusbandId,
                        principalTable: "Births",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Marriages_Births_WifeId",
                        column: x => x.WifeId,
                        principalTable: "Births",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_HusbandId",
                table: "Marriages",
                column: "HusbandId");

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_WifeId",
                table: "Marriages",
                column: "WifeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deaths");

            migrationBuilder.DropTable(
                name: "Marriages");

            migrationBuilder.DropTable(
                name: "Births");
        }
    }
}
