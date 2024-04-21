import {Component, OnInit} from '@angular/core';
import {Movie} from "../../model/movie";
import {ActivatedRoute, Router} from "@angular/router";
import {MovieService} from "../../service/movie.service";
import {FormsModule, NgForm} from "@angular/forms";

@Component({
  selector: 'app-movie-edit',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './movie-edit.component.html',
  styleUrl: './movie-edit.component.css'
})
export class MovieEditComponent implements OnInit {
  movie: Movie = {} as Movie;
  movieCopy: Movie = {} as Movie;

  constructor(private movieService: MovieService,
              private router: Router,
              private route: ActivatedRoute,) {
  }

  ngOnInit() {
    const movieId = +this.route.snapshot.paramMap.get('id')!;
    if (movieId === null || isNaN(movieId)) {
      this.router.navigate(['/error']).then(() => {
      });
      return;
    }

    console.log(movieId);

    this.movieService.getMovieById(movieId).subscribe({
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
      this.movieService.updateMovie(this.movie).subscribe({
        next: () => {
          this.router.navigate(["/movie-details", this.movie.id]);
        },
        error: error => {
          this.router.navigate(["/error"]).then(() => {
          });
          console.error('Error updating movie:', error);
        }
      });
    }
  }

  deleteMovieById(id: number) {
    this.movieService.deleteMovieById(id).subscribe({
      next: () => {
        this.router.navigate(["/movie-get"]);
      },
      error: error => {
        this.router.navigate(["/error"]).then(() => {
        })
      }
    })
  }

  resetForm(){
    this.movie = {...this.movieCopy};
  }
}
