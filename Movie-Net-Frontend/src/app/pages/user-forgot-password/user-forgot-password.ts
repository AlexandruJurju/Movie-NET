import {Component} from '@angular/core';
import {Router} from "@angular/router";
import {AuthenticationService, ForgotPasswordDto, UserDto} from "../../services/swagger";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-user-forgot-password',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './user-forgot-password.html',
  styleUrl: './user-forgot-password.scss'
})
export class UserForgotPassword {
  form: FormGroup;

  constructor(private router: Router,
              private authenticationService: AuthenticationService,
              private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onForgotPassword() {
    if (this.form.valid) {
      const forgotPasswordDto: ForgotPasswordDto = {
        email: this.form.value.email
      };
      this.authenticationService.forgotPassword(forgotPasswordDto).subscribe({
        next: (userDto: UserDto) => {
          console.log('Reset password email sent', userDto);
          this.router.navigate(['user-reset-password', userDto.id]);
        },
        error: (error) => {
          console.error('Error resetting password', error);
        }
      });
    }
  }

  onLogin() {
    this.router.navigate(["user-login"])
  }

  onRegister() {
    this.router.navigate(["user-register"])
  }
}
