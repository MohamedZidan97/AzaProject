using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSupplierField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "suppliers",
                newName: "SupplierLastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "suppliers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierFirstName",
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
                name: "Email",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "SupplierFirstName",
                table: "suppliers");

            migrationBuilder.RenameColumn(
                name: "SupplierLastName",
                table: "suppliers",
                newName: "SupplierName");
        }
    }
}
