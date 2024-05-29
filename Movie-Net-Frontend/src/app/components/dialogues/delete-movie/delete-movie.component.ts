import {Component} from '@angular/core';
import {MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle} from "@angular/material/dialog";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-delete-movie',
  standalone: true,
  imports: [
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatButton,
    MatDialogClose
  ],
  templateUrl: './delete-movie.component.html',
  styleUrl: './delete-movie.component.scss'
})
export class DeleteMovieComponent {


  constructor(public dialogRef: MatDialogRef<DeleteMovieComponent>) {
  }

}
