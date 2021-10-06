import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';
import { JwtHelperService } from "@auth0/angular-jwt";
import { map } from 'rxjs/operators';
import { Client } from './interfaces/client';
import { Doctor } from './interfaces/doctor';
import { Router } from '@angular/router';
import { IUser } from './interfaces/IUser';
import { Appointment } from './interfaces/appointments';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  helper = new JwtHelperService();

  decodedToken = this.helper.decodeToken(localStorage.getItem("jwt")!)
  // currentUser: IUser = {
  //   id: this.decodedToken.userId || null!,
  //   username: this.decodedToken.nameid || null!,
  //   email: this.decodedToken.email  || null!,
  //   role: this.decodedToken.role  || null!,
  // }
  currentUser: IUser = {
    id: null || this.decodedToken?.userId,
    email: null ||  this.decodedToken?.email,
    role: null ||  this.decodedToken?.role,
  }
  currentAppointment: Appointment = {
    id: null || this.decodedToken?.appointmentId,
    dateCreated: null || this.decodedToken?.dateCreated,
    clientId: null || this.decodedToken?.clientId,
    doctorId: null || this.decodedToken?.doctorId,
    clientFirstName: null || this.decodedToken?.clientFirstName,
    clientLastName: null || this.decodedToken?.clientLastName,
    clientContact: null || this.decodedToken?.clientContact,
    patientSymptoms: null || this.decodedToken?.patientSymptoms,
    startTime: null || this.decodedToken?.startTime,
    endTime: null || this.decodedToken?.endTime,
    client: null || this.decodedToken?.client,
    doctor: null || this.decodedToken?.doctor,
  }
  
  constructor(private http: HttpClient, private router: Router) { }

  setAppointment(data: any): Observable<Appointment> {
    return this.http.post(`${baseUrl}auth/Appointment`, data)
      .pipe(
        map((response: any) => {
          const decodeToken = this.helper.decodeToken(response.token);
          this.currentAppointment.id = decodeToken.appointmentId;
          this.currentAppointment.dateCreated = decodeToken.dateCreated;
          this.currentAppointment.clientId = decodeToken.clientId;
          this.currentAppointment.doctorId = decodeToken.doctorId;
          this.currentAppointment.clientFirstName = decodeToken.clientFirstName;
          this.currentAppointment.clientLastName = decodeToken.clientLastName;
          this.currentAppointment.clientContact = decodeToken.clientContact,
          this.currentAppointment.patientSymptoms = decodeToken.patientSymptoms;
          this.currentAppointment.startTime = decodeToken.startTime;
          this.currentAppointment.endTime = decodeToken.endTime;
          this.currentAppointment.client = decodeToken.client;
          this.currentAppointment.doctor = decodeToken.doctor;
          localStorage.setItem('jwt', response.token);
          return this.currentAppointment;
        })
      );
  }
  loginClient(data: any): Observable<IUser> {
    return this.http.post(`${baseUrl}auth/LoginClient`, data)
      .pipe(
        map((response: any) => {
          const decodeToken = this.helper.decodeToken(response.token);
          this.currentUser.id = decodeToken.userId;
          this.currentUser.email = decodeToken.email;
          this.currentUser.role = decodeToken.role;
          localStorage.setItem('jwt', response.token);
          return this.currentUser;
        })
      );
  }
  loginDoctor(data: any): Observable<IUser> {
    return this.http.post(`${baseUrl}auth/LoginDoctor`, data)
      .pipe(
        map((response: any) => {
          const decodeToken = this.helper.decodeToken(response.token);
          this.currentUser.id = decodeToken.userId;
          this.currentUser.email = decodeToken.email;
          this.currentUser.role = decodeToken.role;
          localStorage.setItem('jwt', response.token);
          return this.currentUser;
        })
      );
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('jwt')!;
    return !this.helper.isTokenExpired(token);
  }

  logout() {
    this.currentUser = {
      id: null!,
    email: null!,
    role: null!,
    }
    localStorage.removeItem('jwt');
    this.router.navigate(['/login']);
  }

}
