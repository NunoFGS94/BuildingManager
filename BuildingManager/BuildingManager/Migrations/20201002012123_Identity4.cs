using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingManager.Migrations
{
    public partial class Identity4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "BuildingActivities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "BuildingActivities");
        }
    }
}
