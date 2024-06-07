using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateData",
                table: "Categories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreateData",
                table: "Books",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Categories",
                newName: "CreateData");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Books",
                newName: "CreateData");
        }
    }
}
