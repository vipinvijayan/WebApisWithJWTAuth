using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DryCleanerAppDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnLoginLogStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginStatus",
                table: "loginLog",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginStatus",
                table: "loginLog");
        }
    }
}
