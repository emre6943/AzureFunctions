using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundaApiScraper.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaginationController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaginationControllers",
                columns: table => new
                {
                    HasTuin = table.Column<bool>(type: "bit", nullable: false),
                    PageSize = table.Column<int>(type: "int", nullable: false),
                    LastFetchedPage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaginationControllers", x => x.HasTuin);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaginationControllers");
        }
    }
}
