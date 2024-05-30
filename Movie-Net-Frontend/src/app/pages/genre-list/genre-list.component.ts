import {Component, OnInit} from '@angular/core';
import {NgForOf} from "@angular/common";
import {GenreDto, GenreService} from "../../services/swagger";
import {MatCell, MatCellDef, MatColumnDef, MatHeaderCell, MatHeaderCellDef, MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef, MatTable} from "@angular/material/table";
import {MatButton} from "@angular/material/button";
import {MatSort} from "@angular/material/sort";
import {MatTooltip} from "@angular/material/tooltip";
import {MatPaginator} from "@angular/material/paginator";
import {MatDialog} from "@angular/material/dialog";
import {GenreEditDialogComponent} from "../../components/dialogues/edit-genre-dialog/genre-edit-dialog.component";
import {DeleteDialogComponent} from "../../components/dialogues/delete-dialog/delete-dialog.component";

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

  constructor(
    private genreService: GenreService,
    private dialog: MatDialog,) {
  }

  ngOnInit() {
    this.findAllGenres();
  }

  findAllGenres(): void {
    this.genreService.findAllGenres().subscribe(genres => this.genres = genres);
  }

  openEditDialog(enterAnimationDuration: string, exitAnimationDuration: string, genreDto: GenreDto): void {
    const dialogRef = this.dialog.open(GenreEditDialogComponent, {
      width: '400px',
      enterAnimationDuration,
      exitAnimationDuration,
      data: {
        genreId: genreDto.id,
        genreName: genreDto.name,
        presentGenres: this.genres.map(genre => genre.name),
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const newGenreName: string = result;
        const newGenre: GenreDto = {
          id: genreDto.id,
          name: newGenreName,
        };

        this.genreService.updateGenre(genreDto.id, newGenre).subscribe({
          next: result => {
            console.log("genre updated successfully")
            this.findAllGenres();
          }
        })
      }
    });

  }

  openDeleteDialog(enterAnimationDuration: string, exitAnimationDuration: string, genreDto: GenreDto): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    })

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
      if (result == true) {
        this.genreService.deleteGenre(genreDto.id).subscribe({
          next: result => {
            this.findAllGenres()
          }
        });
      }
    })
  }
}
