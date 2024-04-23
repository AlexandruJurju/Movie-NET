import {Component} from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";
import {AuthenticationService, LoginRequestDto} from "../../services";
import {Router} from "@angular/router";

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
      next: (response) => {
        console.log("Login successful logged in", response);

        // save token to local storage
        localStorage.setItem('token', response.token);
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
