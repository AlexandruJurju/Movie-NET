import {Routes} from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {UploadMovieComponent} from "./pages/upload-movie/upload-movie.component";
import {GetMoviesComponent} from "./pages/get-movies/get-movies.component";
import {RegisterComponent} from "./pages/register/register.component";
import {LoginComponent} from "./pages/login/login.component";
import {MovieDetailsComponent} from "./pages/movie-details/movie-details.component";
import {ErrorComponent} from "./pages/error/error.component";

export const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'upload-movie', component: UploadMovieComponent},
  {path: 'find-movies', component: GetMoviesComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'error', component: ErrorComponent},
  {path: 'movie-details/:id', component: MovieDetailsComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
];
