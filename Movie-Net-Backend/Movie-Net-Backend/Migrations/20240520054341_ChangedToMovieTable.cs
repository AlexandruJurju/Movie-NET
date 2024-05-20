using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Net_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_genre_GenresId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_movie_MoviesId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_actor_ActorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_movie_MovieId",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreMovie",
                table: "GenreMovie");

            migrationBuilder.RenameTable(
                name: "MovieActors",
                newName: "movie_actor");

            migrationBuilder.RenameTable(
                name: "GenreMovie",
                newName: "movie_genre");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_MovieId",
                table: "movie_actor",
                newName: "IX_movie_actor_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_ActorId",
                table: "movie_actor",
                newName: "IX_movie_actor_ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "movie_genre",
                newName: "IX_movie_genre_MoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_actor",
                table: "movie_actor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_genre",
                table: "movie_genre",
                columns: new[] { "GenresId", "MoviesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actor_actor_ActorId",
                table: "movie_actor",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_actor_movie_MovieId",
                table: "movie_actor",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genre_genre_GenresId",
                table: "movie_genre",
                column: "GenresId",
                principalTable: "genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movie_genre_movie_MoviesId",
                table: "movie_genre",
                column: "MoviesId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_actor_actor_ActorId",
                table: "movie_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_actor_movie_MovieId",
                table: "movie_actor");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_genre_genre_GenresId",
                table: "movie_genre");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_genre_movie_MoviesId",
                table: "movie_genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_genre",
                table: "movie_genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_actor",
                table: "movie_actor");

            migrationBuilder.RenameTable(
                name: "movie_genre",
                newName: "GenreMovie");

            migrationBuilder.RenameTable(
                name: "movie_actor",
                newName: "MovieActors");

            migrationBuilder.RenameIndex(
                name: "IX_movie_genre_MoviesId",
                table: "GenreMovie",
                newName: "IX_GenreMovie_MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actor_MovieId",
                table: "MovieActors",
                newName: "IX_MovieActors_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_movie_actor_ActorId",
                table: "MovieActors",
                newName: "IX_MovieActors_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreMovie",
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_genre_GenresId",
                table: "GenreMovie",
                column: "GenresId",
                principalTable: "genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_movie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_actor_ActorId",
                table: "MovieActors",
                column: "ActorId",
                principalTable: "actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_movie_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
