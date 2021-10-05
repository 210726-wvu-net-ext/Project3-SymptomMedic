import { Injectable } from '@angular/core';
import { observable, Observable, of, throwError} from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { Router } from '@angular/router';
import { baseUrl } from 'src/environments/environment';
import { Doctor } from './interfaces/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private doctorUrl = `${baseUrl}doctor`;

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  getDoctors(): Observable<Doctor[]>
  {
    return this.http.get<Doctor[]>(this.doctorUrl)
      .pipe(
        //tap(_ => this.log('fetched doctors')),
        catchError(this.handleError<Doctor[]>('getDoctor', [])
      ));
  }

  getDoctor(id: number): Observable<Doctor>
  {
    const url = `${this.doctorUrl}/${id}`;
    return this.http.get<Doctor>(url)
            .pipe(
              //tap(_ => this.log(`fetched Doctor id=${id}`)),
              catchError(this.handleError<Doctor>(`getDoctor id={id}`))
            );

  }

  /** POST: add a new Doctor to the server */
  addDoctor(doctor: Doctor): Observable<Doctor>{
    return this.http.post<Doctor>(this.doctorUrl, doctor, this.httpOptions).pipe(
      //tap((newDoctor: Doctor) => this.log(`added Doctor w/ id=${newDoctor.id}`)),
      catchError(this.handleError1));
  }

  handleError1(error: HttpErrorResponse){

   return throwError(error.error);
  }

  /** PUT: update the Doctor on the server */
  updateDoctor(id: number, doctor: Doctor): Observable<any> {
    const url = `${this.doctorUrl}/${id}`;
    return this.http.put<Doctor>(url, doctor, this.httpOptions).pipe(
      //tap(_ => this.log(`updated Doctor id=${Doctor.id}`)),
      catchError(this.handleError<any>('updateDoctor'))
    );
  }

  /** DELETE: delete the Doctor from the server */
  deleteDoctor(id: number): Observable<Doctor> {
    const url = `${this.doctorUrl}/${id}`;

    return this.http.delete<Doctor>(url, this.httpOptions).pipe(
      //tap(_ => this.log(`deleted Doctor id=${id}`)),
      catchError(this.handleError<Doctor>('deleteDoctor'))
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
