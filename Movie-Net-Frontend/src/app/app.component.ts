import {Component} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {MenuComponent} from "./components/menu/menu.component";
import {ApiModule} from "./services/swagger";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    MenuComponent,
    ApiModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Movie-Net-Frontend';
}
