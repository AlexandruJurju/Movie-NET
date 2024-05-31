import {Component} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {MovieDto, MovieService} from "../../services/swagger";
import {MatCard} from "@angular/material/card";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButton} from "@angular/material/button";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-movie-save',
  standalone: true,
  imports: [
    FormsModule,
    MatCard,
    MatFormField,
    MatInput,
    MatButton,
    MatLabel,
    ReactiveFormsModule,
    MatError,
    NgIf
  ],
  templateUrl: './movie-save.component.html',
  styleUrl: './movie-save.component.scss'
})
export class MovieSaveComponent {
  form: FormGroup = this.formBuilder.group(
    {
      title: new FormControl('', [Validators.required]),
      headline: new FormControl('', [Validators.required]),
      overview: new FormControl('', [Validators.required]),
      releaseDate: new FormControl('', [Validators.required]),
      posterUrl: new FormControl('', [Validators.required]),
    }
  )

  constructor(
    private movieService: MovieService,
    private router: Router,
    private formBuilder: FormBuilder,) {
  }

  saveMovie() {
    const movie = this.form.value;

    this.movieService.saveMovie(movie).subscribe({
      next: (response) => {
        this.router.navigate(["/home"]);
        console.log('Upload successful', response);
      },
      error: (error) => {
        console.error('Upload failed', error);
      }
    });

  }
}
