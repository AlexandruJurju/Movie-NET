import {Component} from '@angular/core';
import {FormBuilder, FormControl, ReactiveFormsModule, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {NgIf} from "@angular/common";
import {AuthenticationService, RegisterRequestDto} from "../../services/swagger";
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from "@angular/material/card";
import {MatError, MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-user-register',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf,
    MatCardHeader,
    MatCard,
    MatCardContent,
    MatFormField,
    MatInput,
    MatError,
    MatButton,
    MatCardTitle
  ],
  templateUrl: './user-register.component.html',
  styleUrl: './user-register.component.scss'
})
export class UserRegisterComponent {

  errorMessage: string | null = null;

  // validate form data
  registerForm = this.formBuilder.group({
    username: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    // todo: use custom validator for matching passwords
    passwordConfirm: new FormControl('', [Validators.required]),
  });

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  register() {
    if (this.registerForm.valid) {
      const registerRequestDto = {
        username: this.registerForm.value.username!,
        email: this.registerForm.value.email!,
        password: this.registerForm.value.password!,
      }

      this.authenticationService.registerUser(registerRequestDto).subscribe({
        next: (response) => {
          console.log("Registration successful", response);

          // navigate to login page
          this.router.navigate(["/user-login"]).then(() => {
          })
        },
        error: (error) => {
          console.error('Registration failed', error);
          this.errorMessage = error.error.reasons[0].message;
        }
      })
    }
  }

}
