import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef, MatDialogTitle} from "@angular/material/dialog";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatButton} from "@angular/material/button";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-save-genre-dialog',
  standalone: true,
  imports: [
    FormsModule,
    MatButton,
    MatDialogActions,
    MatDialogContent,
    MatDialogTitle,
    MatError,
    MatFormField,
    MatInput,
    MatLabel,
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './save-genre-dialog.component.html',
  styleUrl: './save-genre-dialog.component.scss'
})
export class SaveGenreDialogComponent implements OnInit {
  inputData: any;

  form = this.formBuilder.group({
    genreName: [null, [Validators.required]],
  })

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public dialogRef: MatDialogRef<SaveGenreDialogComponent>,
              private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.inputData = this.data;
  }

  saveGenre() {
    if (this.form.valid) {
      const newGenre = this.form.value.genreName;
      if (this.inputData.presentGenres.includes(newGenre)) {
        this.form.controls['genreName'].setErrors({'alreadyPresent': true});
      } else {
        this.dialogRef.close(newGenre);
      }
    }
  }
}
