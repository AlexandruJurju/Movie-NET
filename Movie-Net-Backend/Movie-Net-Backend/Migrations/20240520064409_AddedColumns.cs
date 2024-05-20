using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Net_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_actor_actor_ActorId",
                table: "movie_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_actor_movie_MovieId",
                table: "movie_actor");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "movie_actor",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "movie_actor",
                newName: "actor_id");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actor_MovieId",
                table: "movie_actor",
                newName: "IX_movie_actor_movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actor_ActorId",
                table: "movie_actor",
                newName: "IX_movie_actor_actor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actor_actor_actor_id",
                table: "movie_actor",
                column: "actor_id",
                principalTable: "actor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actor_movie_movie_id",
                table: "movie_actor",
                column: "movie_id",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_actor_actor_actor_id",
                table: "movie_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_actor_movie_movie_id",
                table: "movie_actor");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "movie_actor",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "actor_id",
                table: "movie_actor",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actor_movie_id",
                table: "movie_actor",
                newName: "IX_movie_actor_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actor_actor_id",
                table: "movie_actor",
                newName: "IX_movie_actor_ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actor_actor_ActorId",
                table: "movie_actor",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actor_movie_MovieId",
                table: "movie_actor",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
