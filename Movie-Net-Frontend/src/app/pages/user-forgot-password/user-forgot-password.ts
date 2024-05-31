import {Component} from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import {AuthenticationService, ForgotPasswordDto, UserDto} from "../../services/swagger";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from "@angular/material/card";
import {MatError, MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {NgIf} from "@angular/common";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-user-forgot-password',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatCardTitle,
    MatCardContent,
    MatCardHeader,
    MatFormField,
    MatInput,
    MatError,
    NgIf,
    MatButton,
    RouterLink
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

  // todo: change code verification and new password to separate pages
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
