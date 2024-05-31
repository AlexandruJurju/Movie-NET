import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute} from "@angular/router";
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {AuthenticationService, ResetPasswordDto, UserDto, UserService} from "../../services/swagger";
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from "@angular/material/card";
import {MatFormField} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-user-reset-password',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatCardHeader,
    MatCard,
    MatCardContent,
    MatFormField,
    MatInput,
    MatButton,
    MatCardTitle
  ],
  templateUrl: './user-reset-password.html',
  styleUrls: ['./user-reset-password.scss']
})
export class UserResetPassword implements OnInit {
  userDto = {} as UserDto;
  // todo: validator for password match
  form = this.formBuilder.group({
    password: ['', [Validators.required]],
    confirmPassword: ['', Validators.required]
  })

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private authenticationService: AuthenticationService
  ) {
  }

  ngOnInit(): void {
    const userId = +this.route.snapshot.paramMap.get('id')!;
    if (userId === null || isNaN(userId)) {
      this.router.navigate(['/error']);
      return;
    }

    console.log(userId);

    this.userService.findUserById(userId).subscribe({
      next: user => {
        if (!user) {
          this.router.navigate(['/error']);
          return;
        }

        this.userDto = user;
      },
    })
  }

  passwordMatchValidator(form: FormGroup) {
    const password = form.get('password')?.value;
    const confirmPassword = form.get('confirmPassword')?.value;
    return password === confirmPassword ? null : {mismatch: true};
  }

  resetPassword() {
    // todo: make this better, separate into 2 pages
    if (this.form.valid) {
      const resetPasswordDto: ResetPasswordDto = {
        userId: this.userDto.id,
        newPassword: this.form.value.password!,
        code: "test"
      };
      this.authenticationService.changePassword(resetPasswordDto).subscribe({
        next: () => {
          this.router.navigate(["user-login"]);
        },
        error: (error) => {
          console.error('Error resetting password', error);
        }
      });
    }
  }
}
