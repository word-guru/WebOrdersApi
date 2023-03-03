using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrdersApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embroideries_Orders_OrderId",
                table: "Embroideries");

            migrationBuilder.DropForeignKey(
                name: "FK_Embroideries_Products_ProductId",
                table: "Embroideries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Embroideries",
                table: "Embroideries");

            migrationBuilder.RenameTable(
                name: "Embroideries",
                newName: "OrderProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Embroideries_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Embroideries_OrderId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "Embroideries");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "Embroideries",
                newName: "IX_Embroideries_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_OrderId",
                table: "Embroideries",
                newName: "IX_Embroideries_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Embroideries",
                table: "Embroideries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Embroideries_Orders_OrderId",
                table: "Embroideries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Embroideries_Products_ProductId",
                table: "Embroideries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
