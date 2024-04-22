import {Component, inject} from '@angular/core';
import {FormsModule, NgForm} from "@angular/forms";
import {MovieService} from "../../service/movie.service";
import {Movie} from "../../model/movie";
import {Router} from "@angular/router";

@Component({
  selector: 'app-movie-upload',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './upload-movie.component.html',
  styleUrl: './upload-movie.component.css'
})
export class UploadMovieComponent {

  movieService: MovieService = inject(MovieService);
  router: Router = inject(Router);

  onSubmit(movieForm: NgForm) {
    const movie: Movie = movieForm.value;

    // TODO: add reroute to home after upload
    this.movieService.saveMovie(movie).subscribe({
      next: (response) => {
        this.router.navigate(["/home"]).then(() => {
        });
        console.log('Upload successful', response);
      },
      error: (error) => {
        console.error('Upload failed', error);
      }
    });

  }
}
