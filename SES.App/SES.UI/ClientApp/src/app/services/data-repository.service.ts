import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';

import { appConfig } from '../common/app-config';

@Injectable({ providedIn: 'root' })

export class DataRepository {
    constructor(
        private httpClient: HttpClient
    ) { }

    getItem<T>(path: string, appendRootPath: boolean = true): Observable<any> {
        let headers: HttpHeaders = new HttpHeaders();
        // headers = headers.append('Content-Type', 'application/json');

        return this.httpClient
            .get<T>(`${appendRootPath ? appConfig.ApiRootPath : ''}${path}`, { headers: headers })
            .pipe(
                retry(2),
                catchError((e) => this.handleError(e))
            );
    }
    getList<T>(path: string, appendRootPath: boolean = true): Observable<any[]> {
        let headers: HttpHeaders = new HttpHeaders();
        // headers = headers.append('Content-Type', 'application/json');

        return this.httpClient
            .get<T[]>(`${appendRootPath ? appConfig.ApiRootPath : ''}${path}`, { headers: headers })
            .pipe(
                retry(2),
                catchError((e) => this.handleError(e))
            );
    }
    postList<T>(path: string, items: any[], appendRootPath: boolean = true): Observable<any> {
        const obj: string = JSON.stringify(items);

        let headers: HttpHeaders = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.httpClient
            .post<T>(`${appendRootPath ? appConfig.ApiRootPath : ''}${path}`, obj, { headers: headers })
            .pipe(
                retry(2),
                catchError((e) => this.handleError(e))
            );
    }
    postItem<T>(path: string, items: any, appendRootPath: boolean = true): Observable<any> {
        const obj: string = JSON.stringify(items);
        let headers: HttpHeaders = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.httpClient
            .post<T>(`${appendRootPath ? appConfig.ApiRootPath : ''}${path}`, obj, { headers: headers })
            .pipe(
                map((res) => {
                    return res;
                }),
                retry(2),
                catchError((e) => this.handleError(e))
            );
    }

    handleError(error: { Message: any; }): Observable<any[]> {
        return throwError(error.Message || error);
    }
}