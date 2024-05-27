import {Component} from '@angular/core';
import {FormBuilder, FormControl, ReactiveFormsModule, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {NgIf} from "@angular/common";
import {AuthenticationService, RegisterRequestDto} from "../../services/swagger";

@Component({
  selector: 'app-user-register',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './user-register.component.html',
  styleUrl: './user-register.component.scss'
})
export class UserRegisterComponent {

  errorMessage: string | null = null;

  // validate form data
  form = this.formBuilder.nonNullable.group({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
  });

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  onSubmit() {
    console.log("register")
    if (this.form.valid) {
      const registerRequestDto = {
        username: this.form.value.username!,
        email: this.form.value.email!,
        password: this.form.value.password!,
      }
      this.register(registerRequestDto);
    }
  }

  private register(registerRequestDto: RegisterRequestDto) {
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
