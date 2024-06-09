using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCatigories_Categories_CategoryId",
                table: "BookCatigories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCatigories",
                table: "BookCatigories");

            migrationBuilder.DropIndex(
                name: "IX_BookCatigories_BookId",
                table: "BookCatigories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookCatigories",
                newName: "Catigory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCatigories",
                table: "BookCatigories",
                columns: new[] { "BookId", "Catigory" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCatigories",
                table: "BookCatigories");

            migrationBuilder.RenameColumn(
                name: "Catigory",
                table: "BookCatigories",
                newName: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCatigories",
                table: "BookCatigories",
                columns: new[] { "CategoryId", "BookId" });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCatigories_BookId",
                table: "BookCatigories",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCatigories_Categories_CategoryId",
                table: "BookCatigories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
