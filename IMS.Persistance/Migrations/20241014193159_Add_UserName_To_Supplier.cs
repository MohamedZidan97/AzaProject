using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserName_To_Supplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "suppliers");
        }
    }
}
