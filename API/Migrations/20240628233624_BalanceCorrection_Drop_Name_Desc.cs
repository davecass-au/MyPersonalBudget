using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class BalanceCorrection_Drop_Name_Desc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BalanceCorrections");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BalanceCorrections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BalanceCorrections",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BalanceCorrections",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
