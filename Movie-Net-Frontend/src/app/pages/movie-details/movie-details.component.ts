import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {NgForOf} from "@angular/common";
import {Actor, Genre, Movie, MovieService} from "../../services/swagger";

@Component({
  selector: 'app-movie-details',
  standalone: true,
  imports: [
    RouterLink,
    NgForOf
  ],
  templateUrl: './movie-details.component.html',
  styleUrl: './movie-details.component.css'
})
export class MovieDetailsComponent implements OnInit {
  movie: Movie = {} as Movie;
  genres: Genre[] = [];
  actors: Actor[] = [];

  constructor(private movieService: MovieService,
              private router: Router,
              private route: ActivatedRoute,) {
  }

  ngOnInit() {

    this.getMovieFromPath();

    this.getGenresOfMovie();

  }

  // TODO: pass the movie object, not the id
  navigateToUpdateMovie() {
    this.router.navigate(['/movie-edit', this.movie.id]);
  }

  private getActorsOfMovie(){

  }

  private getGenresOfMovie() {
    this.movieService.getGenresOfMovie(this.movie.id).subscribe({
      next: genres => {
        console.log(genres);
        this.genres = genres;
      },
      error: error => {
        console.error('Error fetching genres:', error);
      }
    });
  }

  private getMovieFromPath() {
    const movieId = +this.route.snapshot.paramMap.get('id')!;
    if (movieId === null || isNaN(movieId)) {
      this.router.navigate(['/error']);
      return;
    }

    console.log(movieId);

    this.movieService.findMovieById(movieId).subscribe({
      next: movie => {
        if (!movie) {
          this.router.navigate(['/error']);
          return;
        }
        this.movie = movie;
      },
      error: error => {
        console.error('Error fetching movie:', error);
        this.router.navigate(['/error']);
      }
    });
  }


}
