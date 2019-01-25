import {HttpClient, HttpHeaders, HttpResponseBase} from '@angular/common/http';
import {EMPTY, Observable} from 'rxjs';
import {Inject} from '@angular/core';
import {catchError, retry} from "rxjs/operators";

export class ApiService
{
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {
  }

  protected postAsJson<T>(relativeUrl: string, body: any): Observable<T | Object>
  {
    const json = JSON.stringify(body);
    let url = this.getUrl(relativeUrl);

    return this.http.post(url, json, {headers: ApiService.createJsonHeader()})
      .pipe(catchError((err) => this.catchApiError(err)), retry(1));
  }

  protected putAsJson<T>(relativeUrl: string, body: any): Observable<T | Object>
  {
    const json = JSON.stringify(body);
    let url = this.getUrl(relativeUrl);

    return this.http.put(url, json, {headers: ApiService.createJsonHeader()})
      .pipe(catchError((err) => this.catchApiError(err)), retry(1));
  }

  protected getAsJson<T>(relativeUrl: string): Observable<T | Object>
  {
    let url = this.getUrl(relativeUrl);
    return this.http.get(url, {headers: ApiService.createJsonHeader()})
      .pipe(catchError((err) => this.catchApiError(err)), retry(1));
  }

  protected deleteById<T>(relativeUrl: string, id: string): Observable<T | Object>
  {
    let url = this.getUrl(relativeUrl + "/" + id);
    return this.http.delete(url, {headers: ApiService.createJsonHeader()})
      .pipe(catchError((err) => this.catchApiError(err)), retry(1));
  }

  private catchApiError<T, R>(err: HttpResponseBase): Observable<T | R>
  {
    console.error(err);
    return EMPTY;
  }

  private static createJsonHeader(): HttpHeaders
  {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json; charset=utf-8');
    return headers;
  }

  private getUrl(relativeUrl: string)
  {
    return this.baseUrl + relativeUrl.replace(/^\/+/g, '');
  }
}
