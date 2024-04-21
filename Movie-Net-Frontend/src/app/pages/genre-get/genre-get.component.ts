import {Component} from '@angular/core';
import {Genre} from "../../model/genre";
import {GenreService} from "../../service/genre.service";
import {NgForOf} from "@angular/common";
import {Router} from "@angular/router";

@Component({
  selector: 'app-genre-get',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './genre-get.component.html',
  styleUrl: './genre-get.component.css'
})
export class GenreGetComponent {
  genres: Genre[] = [];
  genreToDelete: Genre = {} as Genre;

  constructor(private genreService: GenreService, private router: Router) {
  }

  ngOnInit() {
    this.getGenres();
  }

  getGenres(): void {
    this.genreService.getAllGenres().subscribe(genres => this.genres = genres);
  }

  editGenre(genre: Genre): void {
    //todo: Navigate to genre edit page
  }

  deleteGenre(genreId: number): void {
    this.genreService.deleteGenreById(genreId).subscribe(() => {
      this.getGenres(); // Refresh the list after deletion
    });
  }

  addGenre(): void {
    this.router.navigate(["/genre-save"])
  }

  setGenreToDelete(genre: Genre) {
    this.genreToDelete = genre;
  }
}
