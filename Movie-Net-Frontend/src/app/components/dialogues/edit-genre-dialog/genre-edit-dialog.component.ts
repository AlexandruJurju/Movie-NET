import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef, MatDialogTitle} from "@angular/material/dialog";
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButton} from "@angular/material/button";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-edit-genre-dialog',
  standalone: true,
  imports: [
    MatDialogContent,
    MatDialogTitle,
    ReactiveFormsModule,
    MatFormField,
    MatInput,
    MatDialogActions,
    MatButton,
    NgIf,
    MatError,
    MatLabel,
    MatDialogTitle
  ],
  templateUrl: './genre-edit-dialog.component.html',
  styleUrl: './genre-edit-dialog.component.scss'
})
export class GenreEditDialogComponent implements OnInit {
  inputData: any;

  form = this.formBuilder.group({
    genreName: [null, [Validators.required]],
  })

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public dialogRef: MatDialogRef<GenreEditDialogComponent>,
              private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.inputData = this.data;
  }

  updateGenre() {
    if (this.form.valid) {
      const newGenre = this.form.value.genreName;
      this.dialogRef.close(newGenre);
    }
  }
}
