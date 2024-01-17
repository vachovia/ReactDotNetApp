using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDotNetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItemDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SpecialTag = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
