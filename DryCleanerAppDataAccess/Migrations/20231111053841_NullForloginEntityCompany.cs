using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DryCleanerAppDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NullForloginEntityCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loginLog_companyEntities_CompanyId",
                table: "loginLog");

            migrationBuilder.DropForeignKey(
                name: "FK_loginLog_users_UserDataId",
                table: "loginLog");

            migrationBuilder.AlterColumn<int>(
                name: "UserDataId",
                table: "loginLog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LoginStatus",
                table: "loginLog",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "loginLog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_loginLog_companyEntities_CompanyId",
                table: "loginLog",
                column: "CompanyId",
                principalTable: "companyEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_loginLog_users_UserDataId",
                table: "loginLog",
                column: "UserDataId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loginLog_companyEntities_CompanyId",
                table: "loginLog");

            migrationBuilder.DropForeignKey(
                name: "FK_loginLog_users_UserDataId",
                table: "loginLog");

            migrationBuilder.AlterColumn<int>(
                name: "UserDataId",
                table: "loginLog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "loginLog",
                keyColumn: "LoginStatus",
                keyValue: null,
                column: "LoginStatus",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LoginStatus",
                table: "loginLog",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "loginLog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_loginLog_companyEntities_CompanyId",
                table: "loginLog",
                column: "CompanyId",
                principalTable: "companyEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_loginLog_users_UserDataId",
                table: "loginLog",
                column: "UserDataId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
