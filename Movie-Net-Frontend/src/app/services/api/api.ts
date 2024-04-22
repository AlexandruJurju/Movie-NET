export * from './actor.service';
import { ActorService } from './actor.service';
export * from './genre.service';
import { GenreService } from './genre.service';
export * from './movie.service';
import { MovieService } from './movie.service';
export const APIS = [ActorService, GenreService, MovieService];
