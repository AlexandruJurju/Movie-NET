using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Net_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ReviewCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_movie_movie_id",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_user_id",
                table: "review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_review",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_review_user_id",
                table: "review");

            migrationBuilder.DropColumn(
                name: "id",
                table: "review");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "review",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "review",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_review_movie_id",
                table: "review",
                newName: "IX_review_MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_review",
                table: "review",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_review_movie_MovieId",
                table: "review",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_UserId",
                table: "review",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_movie_MovieId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_UserId",
                table: "review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_review",
                table: "review");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "review",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "review",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_review_MovieId",
                table: "review",
                newName: "IX_review_movie_id");

            migrationBuilder.AlterColumn<int>(
                name: "movie_id",
                table: "review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "review",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_review",
                table: "review",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_review_user_id",
                table: "review",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_movie_movie_id",
                table: "review",
                column: "movie_id",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_user_id",
                table: "review",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
