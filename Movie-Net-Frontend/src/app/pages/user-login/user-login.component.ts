import {Component} from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";
import {Router, RouterLink} from "@angular/router";
import {AuthenticationResponse, AuthenticationService, LoginRequestDto} from "../../services/swagger";
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from "@angular/material/card";
import {MatError, MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {NgIf} from "@angular/common";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-user-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    RouterLink,
    MatCard,
    MatCardTitle,
    MatCardContent,
    MatFormField,
    MatInput,
    NgIf,
    MatButton,
    MatCardHeader,
    MatError
  ],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.scss'
})
export class UserLoginComponent {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  loginForm = this.formBuilder.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(1)]],
  })

  login() {
    console.log("login")
    if (this.loginForm.valid) {
      const loginRequestDto: LoginRequestDto = {
        email: this.loginForm.value.email!,
        password: this.loginForm.value.password!,
      }

      this.authenticationService.loginUser(loginRequestDto).subscribe({
        next: (response: AuthenticationResponse) => {
          console.log("Login successful logged in", response);

          // save token to local storage
          // todo: find a better way to store the current logged in user
          localStorage.setItem('token', response.token);
          localStorage.setItem('userId', response.userId.toString());
          console.log(response.token);

          this.router.navigate(["/home"]).then(() => {
          })
        },
        error: (error) => {
          console.error('Login failed', error);
        }
      })
    }
  }
}