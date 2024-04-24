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
 *//* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from '../encoder';

import { Observable }                                        from 'rxjs';

import { MovieActorDto } from '../model/movieActorDto';
import { MovieDto } from '../model/movieDto';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class MovieService {

    protected basePath = 'http://localhost:5076';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (const consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     * 
     * 
     * @param movieId 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public addActorToMovie(movieId: number, body?: MovieActorDto, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public addActorToMovie(movieId: number, body?: MovieActorDto, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public addActorToMovie(movieId: number, body?: MovieActorDto, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public addActorToMovie(movieId: number, body?: MovieActorDto, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling addActorToMovie.');
        }


        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('post',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}/actors`,
            {
                body: body,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param genreId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public addGenreToMovie(movieId: number, genreId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public addGenreToMovie(movieId: number, genreId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public addGenreToMovie(movieId: number, genreId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public addGenreToMovie(movieId: number, genreId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling addGenreToMovie.');
        }

        if (genreId === null || genreId === undefined) {
            throw new Error('Required parameter genreId was null or undefined when calling addGenreToMovie.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('post',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}/genres/${encodeURIComponent(String(genreId))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public deleteMovie(movieId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public deleteMovie(movieId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public deleteMovie(movieId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public deleteMovie(movieId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling deleteMovie.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('delete',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public findAllMovies(observe?: 'body', reportProgress?: boolean): Observable<any>;
    public findAllMovies(observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public findAllMovies(observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public findAllMovies(observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/v1/Movie`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public findMovieById(movieId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public findMovieById(movieId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public findMovieById(movieId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public findMovieById(movieId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling findMovieById.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getActorsInMovie(movieId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public getActorsInMovie(movieId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public getActorsInMovie(movieId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public getActorsInMovie(movieId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling getActorsInMovie.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}/actors`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getGenresOfMovie(movieId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public getGenresOfMovie(movieId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public getGenresOfMovie(movieId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public getGenresOfMovie(movieId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling getGenresOfMovie.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}/genres`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param actorId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public removeActorFromMovie(movieId: number, actorId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public removeActorFromMovie(movieId: number, actorId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public removeActorFromMovie(movieId: number, actorId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public removeActorFromMovie(movieId: number, actorId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling removeActorFromMovie.');
        }

        if (actorId === null || actorId === undefined) {
            throw new Error('Required parameter actorId was null or undefined when calling removeActorFromMovie.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('delete',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}/actors/${encodeURIComponent(String(actorId))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param genreId 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public removeGenreFromMovie(movieId: number, genreId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public removeGenreFromMovie(movieId: number, genreId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public removeGenreFromMovie(movieId: number, genreId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public removeGenreFromMovie(movieId: number, genreId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling removeGenreFromMovie.');
        }

        if (genreId === null || genreId === undefined) {
            throw new Error('Required parameter genreId was null or undefined when calling removeGenreFromMovie.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('delete',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}/genres/${encodeURIComponent(String(genreId))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public saveMovie(body?: MovieDto, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public saveMovie(body?: MovieDto, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public saveMovie(body?: MovieDto, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public saveMovie(body?: MovieDto, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('post',`${this.basePath}/api/v1/Movie`,
            {
                body: body,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param movieId 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public updateMovie(movieId: number, body?: MovieDto, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public updateMovie(movieId: number, body?: MovieDto, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public updateMovie(movieId: number, body?: MovieDto, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public updateMovie(movieId: number, body?: MovieDto, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling updateMovie.');
        }


        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('put',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}`,
            {
                body: body,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
