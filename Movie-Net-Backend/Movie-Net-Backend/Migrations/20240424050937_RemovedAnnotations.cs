using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Net_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "movie",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "poster_url",
                table: "movie",
                newName: "PosterUrl");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "genre",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "biography",
                table: "actor",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "profile_picture_url",
                table: "actor",
                newName: "ProfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "actor",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "actor",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "actor",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "movie",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Overview",
                table: "movie",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "movie",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PosterUrl",
                table: "movie",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "genre",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "movie",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "PosterUrl",
                table: "movie",
                newName: "poster_url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "genre",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "genre",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "actor",
                newName: "biography");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "actor",
                newName: "profile_picture_url");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "actor",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "actor",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "actor",
                newName: "birth_date");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "movie",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "overview",
                table: "movie",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "headline",
                table: "movie",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "poster_url",
                table: "movie",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "genre",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
