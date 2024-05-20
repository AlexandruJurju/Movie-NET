/**
 * Movie-Net-Backend
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { GenreDto } from './genreDto';
import { MovieActorDto } from './movieActorDto';

export interface DetailedMovieDto { 
    id: number;
    title: string;
    headline: string;
    overview: string;
    releaseDate: string;
    posterUrl: string;
    genres: Array<GenreDto>;
    movieActors: Array<MovieActorDto>;
}