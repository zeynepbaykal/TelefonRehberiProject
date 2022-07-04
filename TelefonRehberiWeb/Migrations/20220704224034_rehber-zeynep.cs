using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberiWeb.Migrations
{
    public partial class rehberzeynep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rehbers_Users_UserId",
                table: "Rehbers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Rehbers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rehbers_Users_UserId",
                table: "Rehbers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rehbers_Users_UserId",
                table: "Rehbers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Rehbers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rehbers_Users_UserId",
                table: "Rehbers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
