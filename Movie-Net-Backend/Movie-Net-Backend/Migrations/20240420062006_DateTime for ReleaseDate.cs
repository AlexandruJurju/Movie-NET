using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Net_Backend.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeforReleaseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "movie",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "movie",
                newName: "overview");

            migrationBuilder.RenameColumn(
                name: "Headline",
                table: "movie",
                newName: "headline");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movie",
                newName: "id");

            migrationBuilder.AddColumn<DateOnly>(
                name: "release_date",
                table: "movie",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "release_date",
                table: "movie");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "movie",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "overview",
                table: "movie",
                newName: "Overview");

            migrationBuilder.RenameColumn(
                name: "headline",
                table: "movie",
                newName: "Headline");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "movie",
                newName: "Id");
        }
    }
}
