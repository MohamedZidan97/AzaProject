using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Add_Supplier_UserName_In_Report : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Supplier_UserName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supplier_UserName",
                table: "Reports");
        }
    }
}
