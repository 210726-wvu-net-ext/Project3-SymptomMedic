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


  handleError1(error: HttpErrorResponse) {

    return throwError(error.error);
  }
}
