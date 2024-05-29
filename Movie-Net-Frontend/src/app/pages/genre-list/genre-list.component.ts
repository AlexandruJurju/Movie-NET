import {Component, OnInit} from '@angular/core';
import {NgForOf} from "@angular/common";
import {Router} from "@angular/router";
import {GenreDto, GenreService} from "../../services/swagger";
import {MatCell, MatCellDef, MatColumnDef, MatHeaderCell, MatHeaderCellDef, MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef, MatTable} from "@angular/material/table";
import {MatButton} from "@angular/material/button";
import {MatSort} from "@angular/material/sort";
import {MatTooltip} from "@angular/material/tooltip";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-genre-list',
  standalone: true,
  imports: [
    NgForOf,
    MatTable,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderCellDef,
    MatCell,
    MatCellDef,
    MatButton,
    MatHeaderRow,
    MatRow,
    MatHeaderRowDef,
    MatRowDef,
    MatSort,
    MatTooltip,
    MatPaginator
  ],
  templateUrl: './genre-list.component.html',
  styleUrl: './genre-list.component.scss'
})
export class GenreListComponent implements OnInit {
  genres: GenreDto[] = [];
  displayedColumns = ['id', 'genreName', 'edit', 'delete']

  constructor(private genreService: GenreService, private router: Router) {
  }

  ngOnInit() {
    this.findAllGenres();
  }

  findAllGenres(): void {
    this.genreService.findAllGenres().subscribe(genres => this.genres = genres);
    console.log(this.genres)
  }

  // TODO: pass the whole object to page, not just the id, get rid of the call

  editGenre(genre: GenreDto): void {
    this.router.navigate(['/genre-edit', genre.id]);
  }

  deleteGenre(genreId: number): void {
    this.genreService.deleteGenre(genreId).subscribe(() => {
      this.findAllGenres();
    });
  }
}
