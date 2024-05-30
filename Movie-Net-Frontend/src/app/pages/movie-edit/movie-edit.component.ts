import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {FormsModule} from "@angular/forms";
import {NgForOf} from "@angular/common";
import {GenreDto, MovieDto, MovieService} from "../../services/swagger";
import {DxButtonModule} from "devextreme-angular";
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatCard} from "@angular/material/card";
import {MatButton} from "@angular/material/button";
import {MatInput} from "@angular/material/input";
import {MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle} from "@angular/material/dialog";
import {DeleteDialogComponent} from "../../components/dialogs/delete-dialog/delete-dialog.component";


@Component({
  selector: 'app-movie-edit',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    MatLabel,
    DxButtonModule,
    MatFormField,
    MatCard,
    MatButton,
    MatInput,
    MatDialogTitle,
    MatDialogActions,
    MatDialogContent,
    MatDialogClose
  ],
  templateUrl: './movie-edit.component.html',
  styleUrl: './movie-edit.component.scss'
})
export class MovieEditComponent implements OnInit {
  movie: MovieDto = {} as MovieDto;

  constructor(private movieService: MovieService,
              private router: Router,
              private route: ActivatedRoute,
              private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.findMovieFromPath();
  }

  private findMovieFromPath() {
    const movieId = +this.route.snapshot.paramMap.get('id')!;
    if (movieId === null || isNaN(movieId)) {
      this.router.navigate(['/error']).then(() => {
      });
      return;
    }

    this.movieService.findMovieById(movieId).subscribe({
      next: movie => {
        if (!movie) {
          this.router.navigate(['/error']).then(() => {
          });
          return;
        }
        this.movie = movie;
      },
      error: error => {
        console.error('Error fetching movie:', error);
        this.router.navigate(['/error']).then(() => {
        });
      }
    });
  }

  update() {
    this.movieService.updateMovie(this.movie.id, this.movie).subscribe({
      next: () => {
        this.router.navigate(["/movie-details", this.movie.id]).then(() => {
        });
      },
      error: error => {
        this.router.navigate(["/error"]).then(() => {
        });
        console.error('Error updating movie:', error);
      }
    });
  }

  openDeleteDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    })

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
      if (result == true) {
        this.movieService.deleteMovie(this.movie.id).subscribe({
          next: result => {
            //   todo: make a page for admin configuration, redirect to that page
          }
        });
      }
    })
  }

  resetForm() {
    this.findMovieFromPath();
  }

}

