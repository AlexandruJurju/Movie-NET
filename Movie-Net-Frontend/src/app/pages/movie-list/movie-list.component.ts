import {Component, OnInit} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {MovieService} from "../../services/api/movie.service";
import {Movie} from "../../services/model/movie";

@Component({
  selector: 'app-movie-list',
  standalone: true,
  imports: [
    NgIf,
    NgForOf
  ],
  templateUrl: './movie-list.component.html',
  styleUrl: './movie-list.component.css'
})

export class MovieListComponent implements OnInit {
  movies: Movie[] = [];

  constructor(private movieService: MovieService, private router: Router) {
  }

  ngOnInit() {
    this.getMovies();
  }

  getMovies() {
    this.movieService.findAllMovies()
      .subscribe(movies => {
        this.movies = movies;
      })
  }

  goToMovieDetails(id: number) {
    this.router.navigate(['/movie-details', id]);
  }
}
