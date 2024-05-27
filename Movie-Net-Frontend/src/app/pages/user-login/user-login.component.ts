import {Component} from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";
import {Router, RouterLink} from "@angular/router";
import {AuthenticationResponse, AuthenticationService, LoginRequestDto} from "../../services/swagger";
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from "@angular/material/card";
import {MatFormField} from "@angular/material/form-field";
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
    MatCardHeader
  ],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  form = this.formBuilder.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(1)]],
  })

  onSubmit() {
    console.log("login")
    if (this.form.valid) {
      const loginRequestDto: LoginRequestDto = {
        email: this.form.value.email!,
        password: this.form.value.password!,
      }
      this.login(loginRequestDto);
    }
  }

  private login(loginRequestDto: LoginRequestDto) {
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
