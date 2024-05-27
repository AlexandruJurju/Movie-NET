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
  currentUser: UserDto = {} as UserDto;
  roles: string[] = [];

  constructor(
    private tokenService: TokenService,
    private router: Router) {
    this.roles = this.tokenService.getUserRoles();
    console.log(this.roles);
  }

  logout() {
    this.tokenService.removeToken();
    localStorage.clear();
    this.router.navigate(["/home"])
  }

  isUserLoggedIn() {
    return this.tokenService.isTokenValid();
  }

}
