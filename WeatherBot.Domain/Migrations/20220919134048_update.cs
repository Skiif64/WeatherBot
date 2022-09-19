using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherBot.Domain.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommandType",
                table: "LastCommands",
                newName: "CommandName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommandName",
                table: "LastCommands",
                newName: "CommandType");
        }
    }
}
