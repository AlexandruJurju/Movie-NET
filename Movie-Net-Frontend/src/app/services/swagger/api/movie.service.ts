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

import { DetailedMovieDto } from '../model/detailedMovieDto';
import { MovieDto } from '../model/movieDto';
import { MovieDtoPageResponse } from '../model/movieDtoPageResponse';

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

        // authentication (Bearer) required
        if (this.configuration.accessToken) {
            const accessToken = typeof this.configuration.accessToken === 'function'
                ? this.configuration.accessToken()
                : this.configuration.accessToken;
            headers = headers.set('Authorization', 'Bearer ' + accessToken);
        }
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
    public findAllMovies(observe?: 'body', reportProgress?: boolean): Observable<Array<MovieDto>>;
    public findAllMovies(observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<MovieDto>>>;
    public findAllMovies(observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<MovieDto>>>;
    public findAllMovies(observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

        // authentication (Bearer) required
        if (this.configuration.accessToken) {
            const accessToken = typeof this.configuration.accessToken === 'function'
                ? this.configuration.accessToken()
                : this.configuration.accessToken;
            headers = headers.set('Authorization', 'Bearer ' + accessToken);
        }
        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Array<MovieDto>>('get',`${this.basePath}/api/v1/Movie`,
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
     * @param page 
     * @param size 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public findAllMoviesPages(page: number, size: number, observe?: 'body', reportProgress?: boolean): Observable<MovieDtoPageResponse>;
    public findAllMoviesPages(page: number, size: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<MovieDtoPageResponse>>;
    public findAllMoviesPages(page: number, size: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<MovieDtoPageResponse>>;
    public findAllMoviesPages(page: number, size: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (page === null || page === undefined) {
            throw new Error('Required parameter page was null or undefined when calling findAllMoviesPages.');
        }

        if (size === null || size === undefined) {
            throw new Error('Required parameter size was null or undefined when calling findAllMoviesPages.');
        }

        let headers = this.defaultHeaders;

        // authentication (Bearer) required
        if (this.configuration.accessToken) {
            const accessToken = typeof this.configuration.accessToken === 'function'
                ? this.configuration.accessToken()
                : this.configuration.accessToken;
            headers = headers.set('Authorization', 'Bearer ' + accessToken);
        }
        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<MovieDtoPageResponse>('get',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(page))}/${encodeURIComponent(String(size))}`,
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
    public findMovieById(movieId: number, observe?: 'body', reportProgress?: boolean): Observable<DetailedMovieDto>;
    public findMovieById(movieId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<DetailedMovieDto>>;
    public findMovieById(movieId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<DetailedMovieDto>>;
    public findMovieById(movieId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (movieId === null || movieId === undefined) {
            throw new Error('Required parameter movieId was null or undefined when calling findMovieById.');
        }

        let headers = this.defaultHeaders;

        // authentication (Bearer) required
        if (this.configuration.accessToken) {
            const accessToken = typeof this.configuration.accessToken === 'function'
                ? this.configuration.accessToken()
                : this.configuration.accessToken;
            headers = headers.set('Authorization', 'Bearer ' + accessToken);
        }
        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<DetailedMovieDto>('get',`${this.basePath}/api/v1/Movie/${encodeURIComponent(String(movieId))}`,
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

        // authentication (Bearer) required
        if (this.configuration.accessToken) {
            const accessToken = typeof this.configuration.accessToken === 'function'
                ? this.configuration.accessToken()
                : this.configuration.accessToken;
            headers = headers.set('Authorization', 'Bearer ' + accessToken);
        }
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

        // authentication (Bearer) required
        if (this.configuration.accessToken) {
            const accessToken = typeof this.configuration.accessToken === 'function'
                ? this.configuration.accessToken()
                : this.configuration.accessToken;
            headers = headers.set('Authorization', 'Bearer ' + accessToken);
        }
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
