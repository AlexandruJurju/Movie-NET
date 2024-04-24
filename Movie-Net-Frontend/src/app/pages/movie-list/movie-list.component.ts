import {Component, OnInit} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {Router} from "@angular/router";
import {MovieDto, MovieDtoPageResponse, MovieService} from "../../services/swagger";

@Component({
  selector: 'app-movie-list',
  standalone: true,
  imports: [
    NgIf,
    NgForOf
  ],
  templateUrl: './movie-list.component.html',
  styleUrl: './movie-list.component.css'
})

export class MovieListComponent implements OnInit {
  movieResponse: MovieDtoPageResponse = {};
  page = 0;
  size = 4;
  pages: any = [];

  constructor(private movieService: MovieService, private router: Router) {
  }

  ngOnInit() {
    this.findAllMoviesPaged();
  }

  private findAllMoviesPaged() {
    console.log(this.page + " " + this.size);
    this.movieService.findAllMovies_1(this.page, this.size)
      .subscribe({
        next: (books) => {
          this.movieResponse = books;
          console.log(this.movieResponse.content);
          this.pages = Array(this.movieResponse.totalPages)
            .fill(0)
            .map((x, i) => i);
        }
      });
  }

  gotToPage(page: number) {
    this.page = page + 1;
    this.findAllMoviesPaged();
  }

  goToMovieDetails(id: number) {
    this.router.navigate(['/movie-details', id]);
  }

}
