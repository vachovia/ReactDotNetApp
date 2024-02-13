using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDotNetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedRestrictionOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10851584-7191-4dee-a2b5-305ae30a9777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b6e9297-2e21-4998-871c-d261bfc2e775", "AQAAAAIAAYagAAAAEGx0orAwWLdtTAMikIjzS4qAZfXBPZlsTQRJF/NgrM2mg2PhEo3GzT62qzOHJazjZA==", "48aed318-f398-4103-a94e-d365be916dc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8383f68f-764c-4427-92b7-6e98902f5f4e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a983a784-5e90-4d13-beb3-94d6e0b6fcc9", "AQAAAAIAAYagAAAAEH6zmwpy+WAqO+DglMCIfW8vAF95hEVyMWNymWe/Hp4G0HdP3T4fgbmZuVZo1QPo7w==", "eadd3987-58d3-44b2-b8b1-14b1c20d31ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10851584-7191-4dee-a2b5-305ae30a9777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2884e2ca-7c53-454f-9814-7e6daf57c647", "AQAAAAIAAYagAAAAEBY9ufq0mhhaBdwXRNQXbmkuYBVODw3GwGgthFT7K2pMddUrjaqE7Cp2aIXEWA6fqA==", "f9b57091-c1bc-4c9c-a025-b6bd7dcbae59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8383f68f-764c-4427-92b7-6e98902f5f4e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bd08ef9-c1d9-4b99-9831-881bd19d82b3", "AQAAAAIAAYagAAAAEBccj+BxxizJS4aQ6vRySE5vzLhMsXmzNasiQ542fAF3w3zmqv+l6VMpNFj8vs7B6w==", "e7fdb2bd-ac7b-491c-8bf5-4a4ec36e64d8" });
        }
    }
}
