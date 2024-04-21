import {Component, inject} from '@angular/core';
import {FormsModule, NgForm} from "@angular/forms";
import {MovieService} from "../../service/movie.service";
import {Movie} from "../../model/movie";

@Component({
  selector: 'app-upload-movie',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './upload-movie.component.html',
  styleUrl: './upload-movie.component.css'
})
export class UploadMovieComponent {

  movieService: MovieService = inject(MovieService);

  onSubmit(movieForm: NgForm) {
    const movie: Movie = movieForm.value;

    this.movieService.saveMovie(movie).subscribe({
      next: (response) => {
        console.log('Upload successful', response);
      },
      error: (error) => {
        console.error('Upload failed', error);
      }
    });

  }
}
