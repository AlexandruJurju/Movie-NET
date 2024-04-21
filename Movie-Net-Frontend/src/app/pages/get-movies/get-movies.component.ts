import {Component, inject} from '@angular/core';
import {Movie} from "../../model/movie";
import {MovieService} from "../../service/movie.service";
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-get-movies',
  standalone: true,
  imports: [
    NgIf,
    NgForOf
  ],
  templateUrl: './get-movies.component.html',
  styleUrl: './get-movies.component.css'
})

export class GetMoviesComponent {
  movies: Movie[] = [];
  movieService: MovieService = inject(MovieService);

  getMovies() {
    this.movieService.getAllMovies()
      .subscribe(movies => {
        this.movies = movies;
      })
  }
}
