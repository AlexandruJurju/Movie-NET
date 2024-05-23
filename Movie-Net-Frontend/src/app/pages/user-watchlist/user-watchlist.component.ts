import {Component, OnInit} from '@angular/core';
import {MovieDto, WatchListService} from "../../services/swagger";
import {Router} from "@angular/router";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-user-watchlist',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './user-watchlist.component.html',
  styleUrl: './user-watchlist.component.css'
})
export class UserWatchlistComponent implements OnInit {

  constructor(
    private watchlistService: WatchListService,
    private router: Router) {
  }

  movies: MovieDto[] = [];

  ngOnInit(): void {
    this.findUserWatchlist();
    console.log(this.movies);
  }

  private findUserWatchlist() {
    console.log("find watchlist")
    const userId = Number(localStorage.getItem('userId'));
    console.log(userId);
    this.watchlistService.findUserWatchlist(userId).subscribe({
      next: (result) => {
        this.movies = result;
      }
    })
  }


  goToMovieDetails(movieId: number) {
    this.router.navigate(['/movie-details', movieId]);
  }
}
