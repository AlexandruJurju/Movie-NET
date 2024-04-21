import {Component, OnInit} from '@angular/core';
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
export class GenreGetComponent implements OnInit{
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

  // TODO: pass the whole object to page, not just the id, get rid of the call
  editGenre(genre: Genre): void {
    this.router.navigate(['/genre-edit', genre.id]);
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
