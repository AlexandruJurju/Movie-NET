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

import { Genre } from '../model/genre';
import { Movie } from '../model/movie';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class GenreService {

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
     * @param genreId
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public deleteGenre(genreId: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public deleteGenre(genreId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public deleteGenre(genreId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public deleteGenre(genreId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (genreId === null || genreId === undefined) {
            throw new Error('Required parameter genreId was null or undefined when calling deleteGenre.');
        }

        let headers = this.defaultHeaders;

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

        return this.httpClient.request<any>('delete',`${this.basePath}/api/v1/Genre/${encodeURIComponent(String(genreId))}`,
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
    public findAllGenres(observe?: 'body', reportProgress?: boolean): Observable<Array<Genre>>;
    public findAllGenres(observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<Genre>>>;
    public findAllGenres(observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<Genre>>>;
    public findAllGenres(observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        let headers = this.defaultHeaders;

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

        return this.httpClient.request<Array<Genre>>('get',`${this.basePath}/api/v1/Genre`,
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
     * @param genreId
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public findGenreById(genreId: number, observe?: 'body', reportProgress?: boolean): Observable<Genre>;
    public findGenreById(genreId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Genre>>;
    public findGenreById(genreId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Genre>>;
    public findGenreById(genreId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (genreId === null || genreId === undefined) {
            throw new Error('Required parameter genreId was null or undefined when calling findGenreById.');
        }

        let headers = this.defaultHeaders;

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

        return this.httpClient.request<Genre>('get',`${this.basePath}/api/v1/Genre/${encodeURIComponent(String(genreId))}`,
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
     * @param genreId
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public getMoviesWithGenre(genreId: number, observe?: 'body', reportProgress?: boolean): Observable<Array<Movie>>;
    public getMoviesWithGenre(genreId: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<Movie>>>;
    public getMoviesWithGenre(genreId: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<Movie>>>;
    public getMoviesWithGenre(genreId: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (genreId === null || genreId === undefined) {
            throw new Error('Required parameter genreId was null or undefined when calling getMoviesWithGenre.');
        }

        let headers = this.defaultHeaders;

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

        return this.httpClient.request<Array<Movie>>('get',`${this.basePath}/api/v1/Genre/${encodeURIComponent(String(genreId))}/movies`,
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
    public saveGenre(body?: Genre, observe?: 'body', reportProgress?: boolean): Observable<Genre>;
    public saveGenre(body?: Genre, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Genre>>;
    public saveGenre(body?: Genre, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Genre>>;
    public saveGenre(body?: Genre, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let headers = this.defaultHeaders;

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
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<Genre>('post',`${this.basePath}/api/v1/Genre`,
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
     * @param genreId
     * @param body
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public updateGenre(genreId: number, body?: Genre, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public updateGenre(genreId: number, body?: Genre, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public updateGenre(genreId: number, body?: Genre, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public updateGenre(genreId: number, body?: Genre, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (genreId === null || genreId === undefined) {
            throw new Error('Required parameter genreId was null or undefined when calling updateGenre.');
        }


        let headers = this.defaultHeaders;

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
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('put',`${this.basePath}/api/v1/Genre/${encodeURIComponent(String(genreId))}`,
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
