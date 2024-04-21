import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Genre} from "../model/genre";
import {BASE_URL} from "../app.settings";
import {Movie} from "../model/movie";

@Injectable({
  providedIn: 'root'
})

export class GenreService {
  constructor(private http: HttpClient) {
  }

  getAllGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${BASE_URL}/api/v1/genre`);
  }

  getGenreById(genreId: number): Observable<Genre> {
    return this.http.get<Genre>(`${BASE_URL}/api/v1/genre/${genreId}`);
  }

  saveGenre(genre: Genre): Observable<Genre> {
    return this.http.post<Genre>(`${BASE_URL}/api/v1/genre`, genre);
  }

  deleteGenreById(genreId: number): Observable<any> {
    return this.http.delete(`${BASE_URL}/api/v1/genre/${genreId}`);
  }

  updateGenre(genre: Genre): Observable<Genre> {
    return this.http.put<Genre>(`${BASE_URL}/api/v1/genre/${genre.id}`, genre);
  }

  getMoviesByGenre(genreId: number): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${BASE_URL}/api/v1/genre/${genreId}/movies`);
  }
}
