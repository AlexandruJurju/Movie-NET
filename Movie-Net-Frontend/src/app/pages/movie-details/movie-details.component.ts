import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {NgForOf, NgIf} from "@angular/common";
import {DetailedMovieDto, MovieService} from "../../services/swagger";

@Component({
  selector: 'app-movie-details',
  standalone: true,
  imports: [
    RouterLink,
    NgForOf,
    NgIf
  ],
  templateUrl: './movie-details.component.html',
  styleUrl: './movie-details.component.css'
})
export class MovieDetailsComponent implements OnInit {
  movie: DetailedMovieDto = {} as DetailedMovieDto;

  constructor(
    private movieService: MovieService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.getMovieInformation();
  }

  // Navigate to update movie page
  navigateToUpdateMovie() {
    this.router.navigate(['/movie-edit', this.movie.id]);
  }

  private getMovieInformation() {
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
        console.log('MOVIE ID ' + movie.id);
        this.movie = movie;
        // Call getGenresOfMovie after getting movie information
      },
      error: error => {
        console.error('Error fetching movie:', error);
        this.router.navigate(['/error']);
      }
    });
  }

  navigateToActorDetails(actorId: number) {
    this.router.navigate(['/actor-details', actorId]);
  }

}
