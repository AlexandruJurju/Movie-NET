import {Component, OnInit} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {MovieDtoPageResponse, MovieService, WatchListService} from "../../services/swagger";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {faHeart, faPlus} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-movie-list',
  standalone: true,
  imports: [
    NgIf,
    NgForOf,
    FontAwesomeModule
  ],
  templateUrl: './movie-list.component.html',
  styleUrl: './movie-list.component.css'
})

export class MovieListComponent implements OnInit {
  movieResponse: MovieDtoPageResponse = {};
  page = 0;
  size = 6;
  pages: any = [];

  constructor(
    private movieService: MovieService,
    private router: Router,
    private watchlistService: WatchListService) {
  }

  ngOnInit() {
    this.findAllMoviesPaged();
  }

  private findAllMoviesPaged() {
    console.log(this.page + " " + this.size);
    this.movieService.findAllMoviesPages(this.page, this.size)
      .subscribe({
        next: (movies) => {
          this.movieResponse = movies;
          console.log(this.movieResponse.content);
          this.pages = Array(this.movieResponse.totalPages)
            .fill(0)
            .map((x, i) => i);
        }
      });
  }

  goToPage(page: number) {
    this.page = page + 1;
    this.findAllMoviesPaged();
  }

  goToMovieDetails(id: number) {
    this.router.navigate(['/movie-details', id]);
  }

  protected readonly localStorage = localStorage;

  addToWatchlist(movieId: number) {
    const userId = Number(localStorage.getItem('userId'));
    this.watchlistService.addMovieToWatchlist(Number(localStorage.getItem('userId')), movieId).subscribe({})
  }

  protected readonly faHeart = faHeart;
  protected readonly faPlus = faPlus;
}
