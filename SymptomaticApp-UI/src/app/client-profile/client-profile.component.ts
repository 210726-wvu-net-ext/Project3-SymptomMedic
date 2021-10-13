import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../patient.service';
import { Client } from '../interfaces/client';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Insurance } from '../interfaces/insurance';
import { Doctor } from '../interfaces/doctor';
import { DoctorService } from '../doctor.service';
import { Appointment } from '../interfaces/appointments';

@Component({
  selector: 'app-client-profile',
  templateUrl: './client-profile.component.html',
  styleUrls: ['./client-profile.component.css']
})
export class ClientProfileComponent implements OnInit {

  @Input() client?: Client;
  @Input() insurance?: Insurance[];
  doctor!: Doctor;
  @Input() appointment?: Appointment[];

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private patientService: PatientService,
    private router: Router,
    private doctorService: DoctorService,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getClient();
  }

  getDoctor(id: number): void {
    this.doctorService.getDoctor(id)
      .subscribe(
        doctor => {
          this.doctor = doctor;
          console.log(doctor);
        },
    );
  }
  getClient(): void {

    const id = this.authService.currentUser.id;
    this.patientService.getClient(id)
      .subscribe(
        client => {
          this.client = client;
          console.log(client);
        },
      );
  }

  getInsurances(): void {
      this.patientService.getInsurances()
      .subscribe(
        insurance =>
        {
          this.insurance = insurance;
        }
      )
  }



}
