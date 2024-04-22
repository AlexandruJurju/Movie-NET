import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {FormsModule, NgForm} from "@angular/forms";
import {Genre} from "../../services/model/genre";
import {GenreService} from "../../services/api/genre.service";

@Component({
  selector: 'app-genre-edit',
  standalone: true,
  templateUrl: './genre-edit.component.html',
  imports: [
    FormsModule
  ],
  styleUrl: './genre-edit.component.css'
})
export class GenreEditComponent implements OnInit {
  genre: Genre = {} as Genre;

  constructor(private genreService: GenreService,
              private router: Router,
              private route: ActivatedRoute,) {
  }

  ngOnInit() {
    const genreId = +this.route.snapshot.paramMap.get('id')!;
    if (genreId === null || isNaN(genreId)) {
      this.router.navigate(['/error']).then(() => {
      });
      return;
    }

    console.log(genreId);

    this.genreService.findGenreById(genreId).subscribe({
      next: genre => {
        if (!genre) {
          this.router.navigate(['/error']).then(() => {
          });
          return;
        }
        this.genre = genre;
      },
      error: error => {
        console.error('Error fetching genre:', error);
        this.router.navigate(['/error']).then(() => {
        });
      }
    });

  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.genreService.updateGenre(this.genre.id, this.genre).subscribe({
        next: () => {
          this.router.navigate(["/genre-list"]).then(() => {
          });
        },
        error: error => {
          this.router.navigate(["/error"]).then(() => {
          });
          console.error('Error updating genre:', error);
        }
      });
    }
  }

}
