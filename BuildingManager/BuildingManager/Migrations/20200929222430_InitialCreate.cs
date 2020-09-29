using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motive = table.Column<string>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    ExitDate = table.Column<DateTime>(nullable: true),
                    ExpectedExitDate = table.Column<DateTime>(nullable: false),
                    exited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
