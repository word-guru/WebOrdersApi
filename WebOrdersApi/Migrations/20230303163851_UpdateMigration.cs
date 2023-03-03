using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOrdersApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Embroideries",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Embroideries_OrderId",
                table: "Embroideries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Embroideries_ProductId",
                table: "Embroideries",
                column: "ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embroideries_Orders_OrderId",
                table: "Embroideries");

            migrationBuilder.DropForeignKey(
                name: "FK_Embroideries_Products_ProductId",
                table: "Embroideries");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Embroideries_OrderId",
                table: "Embroideries");

            migrationBuilder.DropIndex(
                name: "IX_Embroideries_ProductId",
                table: "Embroideries");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Embroideries");
        }
    }
}
