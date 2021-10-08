import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';
import { DoctorService } from '../doctor.service';
import { Doctor } from '../interfaces/doctor';

@Component({
  selector: 'app-app-symptoms',
  templateUrl: './app-symptoms.component.html',
  styleUrls: ['./app-symptoms.component.css']
})
export class AppSymptomsComponent implements OnInit {


  @Input() doctor?: Doctor;

  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }

  constructor(private doctorService: DoctorService, private route: ActivatedRoute, public authService: AuthService) { }


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
        },
      );
  }
}
