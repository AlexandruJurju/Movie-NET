import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Movie} from "../model/movie";
import {BASE_URL} from "../app.settings";
import {Genre} from "../model/genre";

@Injectable({
  providedIn: 'root'
})

export class MovieService {
  constructor(private http: HttpClient) {
  }

  getAllMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${BASE_URL}/api/v1/movie`);
  }

  getMovieById(movieId: number): Observable<Movie> {
    return this.http.get<Movie>(`${BASE_URL}/api/v1/movie/${movieId}`);
  }

  saveMovie(movie: Movie): Observable<Movie> {
    return this.http.post<Movie>(`${BASE_URL}/api/v1/movie`, movie);
  }

  deleteMovieById(movieId: number): Observable<any> {
    return this.http.delete(`${BASE_URL}/api/v1/movie/${movieId}`);
  }

  updateMovie(movie: Movie): Observable<Movie> {
    return this.http.put<Movie>(`${BASE_URL}/api/v1/movie/${movie.id}`, movie);
  }

  getGenresByMovieId(movieId: number): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${BASE_URL}/api/v1/movie/${movieId}/genres`);
  }

}
