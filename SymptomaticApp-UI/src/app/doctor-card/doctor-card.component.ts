import { Component, Input, OnInit } from '@angular/core';

import { DoctorService } from '../doctor.service';
import { Doctor } from '../interfaces/doctor';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrls: ['./doctor-card.component.css']
})
export class DoctorCardComponent implements OnInit {

  @Input() doctor?: Doctor;

  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }

  constructor(private docService: DoctorService, private authService: AuthService) { }

  ngOnInit(): void {
  }

}
