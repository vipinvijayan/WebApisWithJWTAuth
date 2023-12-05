using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DryCleanerAppDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PlaceAddedOnCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LandMark",
                table: "companyEntities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "companyEntities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandMark",
                table: "companyEntities");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "companyEntities");
        }
    }
}
