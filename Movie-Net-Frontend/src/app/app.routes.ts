import {Routes} from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {UploadMovieComponent} from "./pages/movie-upload/upload-movie.component";
import {GetMoviesComponent} from "./pages/movie-get/get-movies.component";
import {RegisterComponent} from "./pages/user-register/register.component";
import {LoginComponent} from "./pages/user-login/login.component";
import {MovieDetailsComponent} from "./pages/movie-details/movie-details.component";
import {ErrorComponent} from "./pages/error/error.component";
import {MovieUpdateComponent} from "./pages/movie-update/movie-update.component";
import {GenreGetComponent} from "./pages/genre-get/genre-get.component";
import {GenreSaveComponent} from "./pages/genre-save/genre-save.component";

export const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'movie-upload', component: UploadMovieComponent},
  {path: 'movie-get', component: GetMoviesComponent},
  {path: 'movie-update/:id', component: MovieUpdateComponent},
  {path: 'movie-details/:id', component: MovieDetailsComponent},
  {path: 'user-register', component: RegisterComponent},
  {path: 'user-login', component: LoginComponent},
  {path: 'genre-get', component: GenreGetComponent},
  {path: 'genre-save', component: GenreSaveComponent},
  {path: 'error', component: ErrorComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},

];
