using Microsoft.EntityFrameworkCore.Migrations;

namespace NotatnikMechanika.Data.Migrations
{
    public partial class D : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Orders");
        }
    }
}
