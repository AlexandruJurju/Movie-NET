import {Component, OnInit} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {MovieDto, MovieDtoPageResponse, MovieService, WatchListService} from "../../services/swagger";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {faHeart, faMinus, faPlus} from "@fortawesome/free-solid-svg-icons";
import {MatSidenavContainer} from "@angular/material/sidenav";
import {MatGridList, MatGridTile} from "@angular/material/grid-list";
import {MatCard, MatCardContent} from "@angular/material/card";
import {MatIcon} from "@angular/material/icon";
import {MatMiniFabButton} from "@angular/material/button";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-movie-list',
  standalone: true,
  imports: [
    NgIf,
    NgForOf,
    FontAwesomeModule,
    MatSidenavContainer,
    MatGridList,
    MatGridTile,
    MatCard,
    MatIcon,
    MatMiniFabButton,
    MatCardContent,
    MatPaginator
  ],
  templateUrl: './movie-list.component.html',
  styleUrl: './movie-list.component.scss'
})

export class MovieListComponent implements OnInit {
  movieResponse: MovieDtoPageResponse = {};
  page = 0;
  size = 6;
  pages: any = [];
  watchlist: number[] = [];

  constructor(
    private movieService: MovieService,
    private router: Router,
    private watchlistService: WatchListService) {
  }

  ngOnInit() {
    this.findMoviesPaged();
    this.findUserWatchlist();
  }

  private findUserWatchlist() {
    const userId = Number(localStorage.getItem('userId'));
    this.watchlistService.findUserWatchlist(userId).subscribe({
      next: (result) => {
        this.watchlist = result.map(movie => movie.id);
      }
    })
  }

  private findMoviesPaged() {
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
    this.page = page;
    this.findMoviesPaged();
  }

  goToMovieDetails(id: number) {
    this.router.navigate(['/movie-details', id]);
  }

  private addToWatchlist(movieId: number) {
    const userId = Number(localStorage.getItem('userId'));
    this.watchlistService.addMovieToWatchlist(userId, movieId).subscribe({})
  }

  private removeFromWatchlist(movieId: number) {
    const userId = Number(localStorage.getItem('userId'));
    this.watchlistService.removeMovieFromWatchlist(userId, movieId).subscribe({})
  }

  public watchlistContainsMovie(movieId: number) {
    return this.watchlist.includes(movieId);
  }

  toggleWatchlist(movieId: number) {
    if (this.watchlistContainsMovie(movieId)) {
      this.removeFromWatchlist(movieId);
    } else {
      this.addToWatchlist(movieId);
    }
  }
}
