import {Component} from '@angular/core';
import {Router} from "@angular/router";
import {AuthenticationService, PasswordResetDto} from "../../services/swagger";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-user-reset-password',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './user-reset-password.component.html',
  styleUrl: './user-reset-password.component.css'
})
export class UserResetPasswordComponent {
  form: FormGroup;

  constructor(private router: Router,
              private authenticationService: AuthenticationService,
              private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onResetPassword() {
    if (this.form.valid) {
      const passwordResetDto: PasswordResetDto = {
        email: this.form.value.email
      };
      this.authenticationService.resetPassword(passwordResetDto).subscribe({
        next: (response) => {
          // todo: redirect to code request for new password
          console.log('Reset password email sent', response);
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
