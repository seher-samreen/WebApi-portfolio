using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Experiences",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Experiences",
                newName: "CompanyName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Experiences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Experiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Experiences",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Experiences",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
