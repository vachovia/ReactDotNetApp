using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDotNetApp.Migrations
{
    /// <inheritdoc />
    public partial class Cleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10851584-7191-4dee-a2b5-305ae30a9777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7961fd65-6482-4500-b8af-dda7bce0f8d1", "AQAAAAIAAYagAAAAEAvxVaxX0/ByOb74hq+vAr+97D2/XnOyk/GFsliOF/WhCrVhJ7jHwt6Jc6ChiOuZ4A==", "bfe55328-2cd1-4043-94f0-6fa7be5fac34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8383f68f-764c-4427-92b7-6e98902f5f4e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba0943cf-1ce4-47bb-9f6f-8b79067e9842", "AQAAAAIAAYagAAAAEFm2vHLtSJQ2LXpK0C68OvmUh8Y7GOdIU3fWG0Noq4RBz0aRoVpN8WHEjhPz4r2J7w==", "3a00ea0a-bb1e-4766-8532-3c13265e688d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
