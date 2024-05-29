import {Component, OnInit} from '@angular/core';
import {ReviewDto, ReviewService, UserDto, UserService} from "../../services/swagger";
import {Router} from "@angular/router";
import {NgOptimizedImage} from "@angular/common";

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [
    NgOptimizedImage
  ],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent implements OnInit {

  user: UserDto = {} as UserDto;
  reviews: ReviewDto[] = [];

  constructor(
    private userService: UserService,
    private reviewService: ReviewService) {
  }

  ngOnInit(): void {
    this.getUserDetails();
    this.getUserReviews();
  }

  private getUserReviews() {
    console.log("get user reviews")
    this.reviewService.findReviewsOfUser(Number(localStorage.getItem('userId'))).subscribe({
      next: reviews => {
        console.log(reviews);
        this.reviews = reviews;
      },
      error: error => {
        console.error('Error posting review:', error);
      }
    });
  }


  private getUserDetails() {
    const userId = Number(localStorage.getItem('userId'));

    this.userService.findUserById(userId).subscribe({
      next: user => {
        this.user = user;
      },
      error: error => {
        console.log(error);
      }
    })
  }

  // todo: account settings
  // todo: upload avatar
//   todo: change password for account settings, logged in user
}
