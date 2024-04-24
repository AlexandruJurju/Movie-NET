import {Component} from '@angular/core';
import {FormsModule, NgForm} from "@angular/forms";
import {Router} from "@angular/router";
import {MovieDto, MovieService} from "../../services/swagger";

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
    const movie: MovieDto = movieForm.value;

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
