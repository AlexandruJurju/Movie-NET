import {Component, inject, OnInit} from '@angular/core';
import {Movie} from "../../model/movie";
import {MovieService} from "../../service/movie.service";
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";

@Component({
  selector: 'app-movie-get',
  standalone: true,
  imports: [
    NgIf,
    NgForOf
  ],
  templateUrl: './get-movies.component.html',
  styleUrl: './get-movies.component.css'
})

export class GetMoviesComponent implements OnInit {
  movies: Movie[] = [];
  movieService: MovieService = inject(MovieService);
  router: Router = inject(Router);

  ngOnInit() {
    this.getMovies();
  }

  getMovies() {
    this.movieService.getAllMovies()
      .subscribe(movies => {
        this.movies = movies;
      })
  }

  goToMovieDetails(id: number) {
    this.router.navigate(['/movie-details', id]);
  }
}
