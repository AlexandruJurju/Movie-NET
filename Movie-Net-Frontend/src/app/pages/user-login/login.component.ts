import {Component, inject} from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-user-login',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  fb = inject(FormBuilder);

  form = this.fb.nonNullable.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  });

  onSubmit() {

  }
}
