import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PatientService } from '../patient.service';
import { Client } from '../interfaces/client';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.css']
})
export class RegisterClientComponent implements OnInit {

  errorMsg: string | undefined;
    form: FormGroup = new FormGroup({

      firstName: new FormControl(''),
      lastName: new FormControl(''),
      password: new FormControl(''),
      gender: new FormControl(''),
      contactMobile: new FormControl(''),
      address: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      country: new FormControl(''),
      zipcode: new FormControl(''),
      birthdate: new FormControl(''),
      email: new FormControl(''),
    });

    loading = false;
    submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private patientService: PatientService,
    private router: Router
  ) { }

  ngOnInit(

  ): void {
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      gender: ['', Validators.required],
      contactMobile: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
      address: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      country: ['United States', Validators.required],
      zipcode: ['', Validators.required],
      birthdate: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
  });
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
      this.submitted = true;
       //stop here if form is invalid
      if (this.form.invalid) {
          return;
      }

      this.loading = true;
      //this.id = this.route.snapshot.params['id'];
      this.patientService.addClient(this.form.value)
        .pipe(first())
        .subscribe(
          data => {
            this.router.navigate(['/login'], {relativeTo: this.route});
            alert("Register successfully!");
          },
          error => {
            this.loading = false;
            alert(error);
          }
        )
  }
}
