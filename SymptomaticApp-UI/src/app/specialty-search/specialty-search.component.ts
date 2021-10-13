import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../doctor.service';
import { Doctor } from '../interfaces/doctor';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-specialty-search',
  templateUrl: './specialty-search.component.html',
  styleUrls: ['./specialty-search.component.css']
})
export class SpecialtySearchComponent implements OnInit {
  doctors: Doctor[] = [];
  searchInput: string = '';
  constructor(private doctorService: DoctorService, public authService: AuthService) {}
  
  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }
  ngOnInit(): void {
    this.getDoctors();
  }
  getDoctors(): void{
    this.doctorService.getDoctors()
      .subscribe(doctors => this.doctors = doctors);
  }
}
