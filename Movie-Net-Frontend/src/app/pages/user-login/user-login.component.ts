import {Component} from '@angular/core';
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthenticationService, LoginRequestDto} from "../../services/swagger";
import {TokenService} from "../../services/token/token.service";

@Component({
  selector: 'app-user-login',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {

  constructor(
    private authenticationService: AuthenticationService,
    private tokenService: TokenService,
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
