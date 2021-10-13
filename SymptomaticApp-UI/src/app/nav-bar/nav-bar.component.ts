import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { Doctor } from '../interfaces/doctor';
import { DoctorService } from '../doctor.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  
  doctors: Doctor[] = [];
  searchInput: string = '';
  constructor(public authService: AuthService, private doctorService: DoctorService) { }

  ngOnInit(): void {
    this.getDoctors();
  }

  logout() {
    this.authService.logout();
    alert("You have logged out. Come back soon!");
  }

  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }
  getDoctors(): void{
    this.doctorService.getDoctors()
      .subscribe(doctors => this.doctors = doctors);
  }

}
