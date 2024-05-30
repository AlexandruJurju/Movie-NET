import {Component, OnInit} from '@angular/core';
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import {TokenService} from "../../services/token/token.service";
import {NgIf, NgOptimizedImage} from "@angular/common";
import {UserDto, UserService} from "../../services/swagger";
import {MatMenu, MatMenuItem, MatMenuTrigger} from "@angular/material/menu";
import {MatButton, MatIconButton} from "@angular/material/button";
import {MatIcon} from "@angular/material/icon";
import {MatToolbar, MatToolbarRow} from "@angular/material/toolbar";

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
    MatToolbar,
    MatToolbarRow
  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})

export class MenuComponent {
  roles: string[] = [];
  username: string | undefined;

  constructor(
    private tokenService: TokenService,
    private router: Router) {
    if (this.isUserLoggedIn()) {
      this.roles = this.tokenService.getUserRoles();
      this.username = this.tokenService.getUsername();
    }
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
