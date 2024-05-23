import {Component} from '@angular/core';
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import {TokenService} from "../../services/token/token.service";
import {NgIf, NgOptimizedImage} from "@angular/common";
import {UserDto} from "../../services/swagger";

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    NgIf,
    NgOptimizedImage
  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})

export class MenuComponent {
  title = "Movie"
  currentUser: UserDto = {} as UserDto;

  constructor(
    private tokenService: TokenService,
    private router: Router) {
  }

  logout() {
    this.tokenService.removeToken();
    this.router.navigate(["/home"])
  }

  isUserLoggedIn() {
    return this.tokenService.isTokenValid();
  }

}
