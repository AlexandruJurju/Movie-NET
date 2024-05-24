import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {NgForOf, NgIf} from "@angular/common";
import {DetailedMovieDto, MovieDto, MovieService, ReviewDto, ReviewService, WatchListService} from "../../services/swagger";
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-movie-details',
  standalone: true,
  imports: [
    NgForOf,
    NgIf,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  movie: DetailedMovieDto = {} as DetailedMovieDto;
  watchlist: MovieDto[] = [];
  form: FormGroup;

  constructor(
    private movieService: MovieService,
    private reviewService: ReviewService,
    private watchlistService: WatchListService,
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
    this.form = this.formBuilder.group({
      text: ['', [Validators.required]],
      score: ['', [Validators.required, Validators.min(1), Validators.max(10)]],
    });
  }

  ngOnInit() {
    this.getMovieDetails();
    this.loadUserWatchlist();
  }

  private getMovieDetails() {
    const movieId = +this.route.snapshot.paramMap.get('id')!;
    if (movieId === null || isNaN(movieId)) {
      this.router.navigate(['/error']);
      return;
    }

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

  // Navigate to update movie page
  navigateToUpdateMovie() {
    this.router.navigate(['/movie-edit', this.movie.id]);
  }

  // Navigate to the page for the actor details
  navigateToActorDetails(actorId: number) {
    this.router.navigate(['/actor-details', actorId]);
  }

  // Submit the review
  submitReview() {
    console.log("submit review")

    if (this.form.valid) {
      const reviewRequest: ReviewDto = {
        userId: Number(localStorage.getItem('userId')),
        movieId: this.movie.id,
        text: this.form.value.text!,
        score: this.form.value.score!
      };

      console.log(reviewRequest)

      this.reviewService.saveReview(reviewRequest).subscribe({
        next: review => {
          window.location.reload();
        },
        error: error => {
          console.error('Error posting review:', error);
        }
      });
    }
  }

  addToWatchlist() {
    console.log("add to watchlist")
    this.watchlistService.addMovieToWatchlist(Number(localStorage.getItem('userId')), this.movie.id).subscribe({})
    window.location.reload();
  }

  removeFromWatchlist() {
    console.log("remove from watchlist")
    this.watchlistService.removeMovieFromWatchlist(Number(localStorage.getItem('userId')), this.movie.id).subscribe({})
    window.location.reload();
  }

  private loadUserWatchlist() {
    const userId = Number(localStorage.getItem('userId'));
    this.watchlistService.findUserWatchlist(userId).subscribe({
      next: movies => {
        this.watchlist = movies;
      },
      error: error => {
        console.error('Error loading watchlist', error);
      }
    })
  }

  isMovieInWatchlist(): boolean {
    const movieId = this.movie.id;
    return this.watchlist.some(movie => movie.id === movieId);
  }

}
