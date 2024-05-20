import {Routes} from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {MovieSaveComponent} from "./pages/movie-save/movie-save.component";
import {MovieListComponent} from "./pages/movie-list/movie-list.component";
import {UserRegisterComponent} from "./pages/user-register/user-register.component";
import {UserLoginComponent} from "./pages/user-login/user-login.component";
import {MovieDetailsComponent} from "./pages/movie-details/movie-details.component";
import {ErrorComponent} from "./pages/error/error.component";
import {MovieEditComponent} from "./pages/movie-edit/movie-edit.component";
import {GenreListComponent} from "./pages/genre-list/genre-list.component";
import {GenreSaveComponent} from "./pages/genre-save/genre-save.component";
import {GenreEditComponent} from "./pages/genre-edit/genre-edit.component";
import {authGuard} from "./services/guard/auth.guard";
import {ActorDetailsComponent} from "./pages/actor-details/actor-details.component";

export const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },

  {
    path: 'user-register',
    component: UserRegisterComponent
  },
  {
    path: 'user-login',
    component: UserLoginComponent
  },

  {
    path: 'movie-save',
    component: MovieSaveComponent,
    canActivate: [authGuard]
  },
  {
    path: 'movie-list',
    component: MovieListComponent,
  },
  {
    path: 'movie-edit/:id',
    component: MovieEditComponent,
    canActivate: [authGuard]
  },
  {
    path: 'movie-details/:id',
    component: MovieDetailsComponent,
    canActivate: [authGuard]
  },

  {
    path: 'genre-list',
    component: GenreListComponent,
  },
  {
    path: 'genre-save',
    component: GenreSaveComponent,
    canActivate: [authGuard]
  },
  {
    path: 'genre-edit/:id',
    component: GenreEditComponent,
    canActivate: [authGuard]
  },

  {
    path: 'actor-details/:id',
    component: ActorDetailsComponent
  },

  {
    path: 'error',
    component: ErrorComponent
  },
  {
    path: '', redirectTo: '/home', pathMatch: 'full'
  },
];
