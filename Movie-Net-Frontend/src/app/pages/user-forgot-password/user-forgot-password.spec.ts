import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserForgotPassword } from './user-forgot-password';

describe('UserResetPasswordComponent', () => {
  let component: UserForgotPassword;
  let fixture: ComponentFixture<UserForgotPassword>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserForgotPassword]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserForgotPassword);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
