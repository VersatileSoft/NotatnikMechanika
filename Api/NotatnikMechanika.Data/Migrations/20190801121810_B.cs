using Microsoft.EntityFrameworkCore.Migrations;

namespace NotatnikMechanika.Data.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SureName",
                table: "Customers",
                newName: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Customers",
                newName: "SureName");
        }
    }
}
