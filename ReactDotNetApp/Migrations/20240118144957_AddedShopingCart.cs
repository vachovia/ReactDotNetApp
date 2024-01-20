using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDotNetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedShopingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10851584-7191-4dee-a2b5-305ae30a9777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c5d6e6d-cfb5-4db7-83ea-8c237a5185fb", "AQAAAAIAAYagAAAAEF6F+A5X33VRG6SZEEHSo1KVl6+NzVuWwjUt9OJ6IN+HabyhmyGtO+XRO6EzP9Wbjg==", "34a20070-7dc1-4b17-8618-3057eaf9cafd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8383f68f-764c-4427-92b7-6e98902f5f4e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccd322e5-0378-465a-b256-34ab8b86d3ff", "AQAAAAIAAYagAAAAEDHTcAVrN6+9cROaXEG8IO58NTk9Ksj7KjzSdW9892Ok8oHYyYxGdnmmpxtXI7exKw==", "168fddfe-2665-4844-9f6d-c776b83ac1e5" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_MenuItemId",
                table: "CartItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10851584-7191-4dee-a2b5-305ae30a9777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0787cfeb-c8ac-4873-8fad-918a0ac9b714", "AQAAAAIAAYagAAAAELGPRCbCa8+Ct96Dfy+lDI8vyd33YmnQP8G4zv+/1+vto9AIHLJMd04ebfUEq5eFXQ==", "c66f4ecf-6ad1-425b-a71b-9b8ff2c6edcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8383f68f-764c-4427-92b7-6e98902f5f4e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4543f8d6-6e56-4998-8653-9d03b6e1cf37", "AQAAAAIAAYagAAAAEKRUpfinOIXVJyQ9mbPDhTOtFF4ugSTNCqSsVdUNcDpEXeeoK9Rjb8P+qlOfuBks6w==", "2bc253d3-bff1-4b4d-ba3d-704fdc4be420" });
        }
    }
}
