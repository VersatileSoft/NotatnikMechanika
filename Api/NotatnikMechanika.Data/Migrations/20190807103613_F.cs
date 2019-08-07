using Microsoft.EntityFrameworkCore.Migrations;

namespace NotatnikMechanika.Data.Migrations
{
    public partial class F : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderToCommodity_Commodities_CommodityId",
                table: "OrderToCommodity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToCommodity_Orders_OrderId",
                table: "OrderToCommodity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToService_Orders_OrderId",
                table: "OrderToService");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToService_Services_ServiceId",
                table: "OrderToService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderToService",
                table: "OrderToService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderToCommodity",
                table: "OrderToCommodity");

            migrationBuilder.RenameTable(
                name: "OrderToService",
                newName: "OrderToServices");

            migrationBuilder.RenameTable(
                name: "OrderToCommodity",
                newName: "OrderToCommodities");

            migrationBuilder.RenameIndex(
                name: "IX_OrderToService_OrderId",
                table: "OrderToServices",
                newName: "IX_OrderToServices_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderToCommodity_OrderId",
                table: "OrderToCommodities",
                newName: "IX_OrderToCommodities_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderToServices",
                table: "OrderToServices",
                columns: new[] { "ServiceId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderToCommodities",
                table: "OrderToCommodities",
                columns: new[] { "CommodityId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToCommodities_Commodities_CommodityId",
                table: "OrderToCommodities",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToCommodities_Orders_OrderId",
                table: "OrderToCommodities",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToServices_Orders_OrderId",
                table: "OrderToServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToServices_Services_ServiceId",
                table: "OrderToServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderToCommodities_Commodities_CommodityId",
                table: "OrderToCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToCommodities_Orders_OrderId",
                table: "OrderToCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToServices_Orders_OrderId",
                table: "OrderToServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToServices_Services_ServiceId",
                table: "OrderToServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderToServices",
                table: "OrderToServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderToCommodities",
                table: "OrderToCommodities");

            migrationBuilder.RenameTable(
                name: "OrderToServices",
                newName: "OrderToService");

            migrationBuilder.RenameTable(
                name: "OrderToCommodities",
                newName: "OrderToCommodity");

            migrationBuilder.RenameIndex(
                name: "IX_OrderToServices_OrderId",
                table: "OrderToService",
                newName: "IX_OrderToService_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderToCommodities_OrderId",
                table: "OrderToCommodity",
                newName: "IX_OrderToCommodity_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderToService",
                table: "OrderToService",
                columns: new[] { "ServiceId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderToCommodity",
                table: "OrderToCommodity",
                columns: new[] { "CommodityId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToCommodity_Commodities_CommodityId",
                table: "OrderToCommodity",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToCommodity_Orders_OrderId",
                table: "OrderToCommodity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToService_Orders_OrderId",
                table: "OrderToService",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToService_Services_ServiceId",
                table: "OrderToService",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
