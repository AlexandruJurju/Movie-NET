import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {FormsModule, NgForm} from "@angular/forms";
import {NgForOf} from "@angular/common";
import {GenreDto, MovieDto, MovieService} from "../../services/swagger";
import {DxButtonModule} from "devextreme-angular";



@Component({
  selector: 'app-movie-edit',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    DxButtonModule
  ],
  templateUrl: './movie-edit.component.html',
  styleUrl: './movie-edit.component.scss'
})
export class MovieEditComponent implements OnInit {
  movie: MovieDto = {} as MovieDto;
  movieCopy: MovieDto = {} as MovieDto;
  genres: GenreDto[] = [];

  constructor(private movieService: MovieService,
              private router: Router,
              private route: ActivatedRoute,) {
  }

  ngOnInit() {
    this.findMovieFromPath();

    this.getGenresOfMovie();
  }

  private getGenresOfMovie() {
    this.movieService.getGenresOfMovie(this.movie.id).subscribe({
      next: genres => {
        this.genres = genres;
      },
      error: error => {
        console.error('Error fetching genres:', error);
      }
    });
  }

  private findMovieFromPath() {
    const movieId = +this.route.snapshot.paramMap.get('id')!;
    if (movieId === null || isNaN(movieId)) {
      this.router.navigate(['/error']).then(() => {
      });
      return;
    }

    console.log(movieId);

    this.movieService.findMovieById(movieId).subscribe({
      next: movie => {
        if (!movie) {
          this.router.navigate(['/error']).then(() => {
          });
          return;
        }
        this.movie = movie;
        this.movieCopy = {...movie};
      },
      error: error => {
        console.error('Error fetching movie:', error);
        this.router.navigate(['/error']).then(() => {
        });
      }
    });
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.movieService.updateMovie(this.movie.id, this.movie).subscribe({
        next: () => {
          this.router.navigate(["/movie-details", this.movie.id]).then(() => {
          });
        },
        error: error => {
          this.router.navigate(["/error"]).then(() => {
          });
          console.error('Error updating movie:', error);
        }
      });
    }
  }

  deleteMovieById(movieId: number) {
    this.movieService.deleteMovie(movieId).subscribe({
      next: () => {
        this.router.navigate(["/movie-list"]).then(() => {
        });
      },
      error: error => {
        this.router.navigate(["/error"]).then(() => {
        })
      }
    })
  }

  resetForm() {
    this.movie = {...this.movieCopy};
  }
}
