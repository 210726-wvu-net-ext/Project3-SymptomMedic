import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../patient.service';
import { Client } from '../interfaces/client';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-client-profile',
  templateUrl: './client-profile.component.html',
  styleUrls: ['./client-profile.component.css']
})
export class ClientProfileComponent implements OnInit {

  @Input() client?: Client;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private patientService: PatientService,
    private router: Router,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getClient();
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



}
