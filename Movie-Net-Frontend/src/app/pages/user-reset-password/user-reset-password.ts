import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute} from "@angular/router";
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {AuthenticationService, ResetPasswordDto, UserDto, UserService} from "../../services/swagger";

@Component({
  selector: 'app-user-reset-password',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './user-reset-password.html',
  styleUrls: ['./user-reset-password.scss']
})
export class UserResetPassword implements OnInit {
  userDto = {} as UserDto;
  form: FormGroup;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private authenticationService: AuthenticationService
  ) {
    this.form = this.formBuilder.group({
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
    }, {validator: this.passwordMatchValidator});
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

  onResetPassword() {
    if (this.form.valid) {
      const resetPasswordDto: ResetPasswordDto = {
        userId: this.userDto.id,
        newPassword: this.form.value.password
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
