import { Injectable } from '@angular/core';
import { observable, Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { Router } from '@angular/router';
import { baseUrl } from 'src/environments/environment';
import { Appointment } from './interfaces/appointments';


@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private appointmentUrl = `${baseUrl}appointment`;

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }
  /** POST: add a new Appointment to the server */
  addAppointment(appointment: Appointment): Observable<Appointment> {
    return this.http.post<Appointment>(this.appointmentUrl, appointment, this.httpOptions).pipe(
      catchError(this.handleError1));
  }


  getAppointment(id: number): Observable<Appointment> {
    const url = `${this.appointmentUrl}/${id}`;
    return this.http.get<Appointment>(url)
      .pipe(
        //tap(_ => this.log(`fetched Appointment id=${id}`)),
        catchError(this.handleError<Appointment>(`getAppointment id={id}`))
      );

  }
  /** GET: gets an Appointment on the server*/

  handleError1(error: HttpErrorResponse) {

    return throwError(error.error);
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
