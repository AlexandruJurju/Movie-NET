import {Component} from '@angular/core';
import {FormsModule, NgForm} from "@angular/forms";
import {Router} from "@angular/router";
import {MovieService} from "../../services/api/movie.service";
import {Movie} from "../../services/model/movie";

@Component({
  selector: 'app-movie-save',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './movie-save.component.html',
  styleUrl: './movie-save.component.css'
})
export class MovieSaveComponent {


  constructor(private movieService: MovieService, private router: Router) {
  }


  onSubmit(movieForm: NgForm) {
    const movie: Movie = movieForm.value;

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
