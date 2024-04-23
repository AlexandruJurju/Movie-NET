import {Component} from '@angular/core';
import {FormsModule, NgForm, ReactiveFormsModule} from "@angular/forms";
import {Router} from "@angular/router";
import {Genre, GenreService} from "../../services/swagger";

@Component({
  selector: 'app-genre-save',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './genre-save.component.html',
  styleUrl: './genre-save.component.css'
})
export class GenreSaveComponent {

  constructor(private genreService: GenreService, private router: Router) {
  }

  onSubmit(genreForm: NgForm) {
    const genre: Genre = genreForm.value;

    this.genreService.saveGenre(genre).subscribe({
      next: (response) => {
        this.router.navigate(["/genre-list"]).then(() => {
        });
        console.log('Save successful', response);
      },
      error: (error) => {
        console.error('Save failed', error);
      }
    });
  }
}
