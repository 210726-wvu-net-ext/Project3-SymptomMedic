import { Component, Input, OnInit } from '@angular/core';
import { DoctorService } from '../doctor.service';
import { Doctor } from '../interfaces/doctor';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-doctor-account',
  templateUrl: './doctor-account.component.html',
  styleUrls: ['./doctor-account.component.css']
})
export class DoctorAccountComponent implements OnInit {

  @Input() doctor?: Doctor;
  constructor(
    private doctorService: DoctorService,
    private route: ActivatedRoute,
    public authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(routeParams => {
      this.getDoctor();
    });
  }

  getDoctor(): void {

    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.doctorService.getDoctor(id)
      .subscribe(
        doctor => {
        this.doctor = doctor;
        }
      );
  }

}
