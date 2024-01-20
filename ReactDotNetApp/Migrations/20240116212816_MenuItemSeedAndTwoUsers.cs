using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactDotNetApp.Migrations
{
    /// <inheritdoc />
    public partial class MenuItemSeedAndTwoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70b4f51c-f566-4ea9-aa48-612759bbafec", null, "User", "USER" },
                    { "78a9a3b6-9647-49a1-b953-49bd82a175e6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10851584-7191-4dee-a2b5-305ae30a9777", 0, "0787cfeb-c8ac-4873-8fad-918a0ac9b714", "user@redmango.com", false, false, null, "System User", "USER@REDMANGO.COM", "USER@REDMANGO.COM", "AQAAAAIAAYagAAAAELGPRCbCa8+Ct96Dfy+lDI8vyd33YmnQP8G4zv+/1+vto9AIHLJMd04ebfUEq5eFXQ==", null, false, "c66f4ecf-6ad1-425b-a71b-9b8ff2c6edcc", false, "user@redmango.com" },
                    { "8383f68f-764c-4427-92b7-6e98902f5f4e", 0, "4543f8d6-6e56-4998-8653-9d03b6e1cf37", "admin@redmango.com", false, false, null, "System Admin", "ADMIN@REDMANGO.COM", "ADMIN@REDMANGO.COM", "AQAAAAIAAYagAAAAEKRUpfinOIXVJyQ9mbPDhTOtFF4ugSTNCqSsVdUNcDpEXeeoK9Rjb8P+qlOfuBks6w==", null, false, "2bc253d3-bff1-4b4d-ba3d-704fdc4be420", false, "admin@redmango.com" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/spring roll.jpg", "Spring Roll", 7.9900000000000002, "" },
                    { 2, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/idli.jpg", "Idli", 8.9900000000000002, "" },
                    { 3, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/pani puri.jpg", "Panu Puri", 8.9900000000000002, "Best Seller" },
                    { 4, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/hakka noodles.jpg", "Hakka Noodles", 10.99, "" },
                    { 5, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/malai kofta.jpg", "Malai Kofta", 12.99, "Top Rated" },
                    { 6, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/paneer pizza.jpg", "Paneer Pizza", 11.99, "" },
                    { 7, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/paneer tikka.jpg", "Paneer Tikka", 13.99, "Chef's Special" },
                    { 8, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/carrot love.jpg", "Carrot Love", 4.9900000000000002, "" },
                    { 9, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/rasmalai.jpg", "Rasmalai", 4.9900000000000002, "Chef's Special" },
                    { 10, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactdotnetstorage.blob.core.windows.net/reactdotnetimages/sweet rolls.jpg", "Sweet Rolls", 3.9900000000000002, "Top Rated" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "70b4f51c-f566-4ea9-aa48-612759bbafec", "10851584-7191-4dee-a2b5-305ae30a9777" },
                    { "78a9a3b6-9647-49a1-b953-49bd82a175e6", "8383f68f-764c-4427-92b7-6e98902f5f4e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70b4f51c-f566-4ea9-aa48-612759bbafec", "10851584-7191-4dee-a2b5-305ae30a9777" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "78a9a3b6-9647-49a1-b953-49bd82a175e6", "8383f68f-764c-4427-92b7-6e98902f5f4e" });

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70b4f51c-f566-4ea9-aa48-612759bbafec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78a9a3b6-9647-49a1-b953-49bd82a175e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10851584-7191-4dee-a2b5-305ae30a9777");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8383f68f-764c-4427-92b7-6e98902f5f4e");
        }
    }
}
