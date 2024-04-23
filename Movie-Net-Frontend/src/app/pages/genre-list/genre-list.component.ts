import {Component, OnInit} from '@angular/core';
import {NgForOf} from "@angular/common";
import {Router} from "@angular/router";
import {Genre, GenreService} from "../../services/swagger";

@Component({
  selector: 'app-genre-list',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './genre-list.component.html',
  styleUrl: './genre-list.component.css'
})
export class GenreListComponent implements OnInit {
  genres: Genre[] = [];
  genreToDelete: Genre = {} as Genre;

  constructor(private genreService: GenreService, private router: Router) {
  }

  ngOnInit() {
    this.findAllGenres();
  }

  findAllGenres(): void {
    this.genreService.findAllGenres().subscribe(genres => this.genres = genres);
  }

  // TODO: pass the whole object to page, not just the id, get rid of the call
  editGenre(genre: Genre): void {
    this.router.navigate(['/genre-edit', genre.id]);
  }

  deleteGenre(genreId: number): void {
    this.genreService.deleteGenre(genreId).subscribe(() => {
      this.findAllGenres(); // Refresh the list after deletion
    });
  }

  addGenre(): void {
    this.router.navigate(["/genre-save"])
  }

  setGenreToDelete(genre: Genre) {
    this.genreToDelete = genre;
  }
}
