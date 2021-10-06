import { Injectable } from '@angular/core';
import { observable, Observable, of, throwError} from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { Router } from '@angular/router';
import { baseUrl } from 'src/environments/environment';
import { Client } from './interfaces/client';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private clientUrl = `${baseUrl}client`;
  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  getClients(): Observable<Client[]>
  {
    return this.http.get<Client[]>(this.clientUrl)
      .pipe(
        //tap(_ => this.log('fetched clients')),
        catchError(this.handleError<Client[]>('getDoctor', [])
      ));
  }

  getClient(id: number): Observable<Client>
  {
    const url = `${this.clientUrl}/${id}`;
    return this.http.get<Client>(url)
            .pipe(
              //tap(_ => this.log(`fetched Client id=${id}`)),
              catchError(this.handleError<Client>(`getClient id={id}`))
            );

  }

  /** POST: add a new Client to the server */
  addClient(client: Client): Observable<Client>{
    return this.http.post<Client>(this.clientUrl, client, this.httpOptions).pipe(
      //tap((newClient: Client) => this.log(`added Client w/ id=${newClient.id}`)),
      catchError(this.handleError1));
  }

  handleError1(error: HttpErrorResponse){

   return throwError(error.error);
  }

  /** PUT: update the Client on the server */
  updateClient(id: number, client: Client): Observable<any> {
    const url = `${this.clientUrl}/${id}`;
    return this.http.put<Client>(url, client, this.httpOptions).pipe(
      //tap(_ => this.log(`updated Client id=${Client.id}`)),
      catchError(this.handleError<any>('updateDoctor'))
    );
  }

  /** DELETE: delete the Client from the server */
  deleteDoctor(id: number): Observable<Client> {
    const url = `${this.clientUrl}/${id}`;

    return this.http.delete<Client>(url, this.httpOptions).pipe(
      //tap(_ => this.log(`deleted Client id=${id}`)),
      catchError(this.handleError<Client>('deleteClient'))
    );
  }

    /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);
      console.log(operation); //create message service

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
