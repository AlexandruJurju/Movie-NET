import {Component, OnInit} from '@angular/core';
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import {TokenService} from "../../services/token/token.service";
import {NgIf, NgOptimizedImage} from "@angular/common";
import {UserDto, UserService} from "../../services/swagger";
import {MatMenu, MatMenuItem, MatMenuTrigger} from "@angular/material/menu";
import {MatButton, MatIconButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {MatToolbar} from "@angular/material/toolbar";

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    NgIf,
    NgOptimizedImage,
    MatMenu,
    MatMenuItem,
    MatIconButton,
    MatMenuTrigger,
    MatIcon,
    MatButton,
    MatToolbar
  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})

export class MenuComponent {
  roles: string[] = [];

  constructor(
    private tokenService: TokenService,
    private userService: UserService,
    private router: Router) {
    this.roles = this.tokenService.getUserRoles();
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
