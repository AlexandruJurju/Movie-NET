import {Component, OnInit} from '@angular/core';
import {MovieService} from "../../service/movie.service";
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {Movie} from "../../model/movie";
import {Genre} from "../../model/genre";
import {join} from "@angular/compiler-cli";
import {NgForOf} from "@angular/common";

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
export class MovieDetailsComponent implements OnInit{
  movie: Movie = {} as Movie;
  genres: Genre[] = [];

  constructor(private movieService: MovieService,
              private router: Router,
              private route: ActivatedRoute,) {
  }

  ngOnInit() {
    const movieId = +this.route.snapshot.paramMap.get('id')!;
    if (movieId === null || isNaN(movieId)) {
      this.router.navigate(['/error']);
      return;
    }

    console.log(movieId);

    this.movieService.getMovieById(movieId).subscribe({
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

    this.movieService.getGenresByMovieId(movieId).subscribe({
      next: genres => {
        console.log(genres);
        this.genres = genres;
      },
      error: error => {
        console.error('Error fetching genres:', error);
      }
    });
  }

  // TODO: pass the movie object, not the id
  navigateToUpdateMovie() {
    this.router.navigate(['/movie-edit', this.movie.id]);
  }
}
