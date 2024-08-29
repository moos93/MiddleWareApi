using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiddleWareApi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "middleWares",
                columns: table => new
                {
                    MiddleWareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleWareName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleWareDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_middleWares", x => x.MiddleWareId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "middleWares");
        }
    }
}
