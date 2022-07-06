using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberiWeb.Migrations
{
    public partial class zeyno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIp",
                table: "Users");
        }
    }
}
