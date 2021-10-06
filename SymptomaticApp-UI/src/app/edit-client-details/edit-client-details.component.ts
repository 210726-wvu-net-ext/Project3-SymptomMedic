import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../patient.service';
import { Client } from '../interfaces/client';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-edit-client-details',
  templateUrl: './edit-client-details.component.html',
  styleUrls: ['./edit-client-details.component.css']
})
export class EditClientDetailsComponent implements OnInit {

  @Input() client?: Client;

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
    private router: Router,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: [this.client?.firstName, Validators.required],
      lastName: [this.client?.lastName, Validators.required],
      contactMobile: [this.client?.contactMobile, Validators.required],
      address: [this.client?.address, Validators.required],
      city: [this.client?.city, Validators.required],
      state: [this.client?.state, Validators.required],
      country: ['United States', Validators.required],
      zipcode: [this.client?.zipcode, Validators.required],
      email: [this.client?.email, [Validators.required, Validators.email]],
    });
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    //stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    const id = this.authService.currentUser.id;
    this.patientService.updateClient(id, this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([`../profile/${id}`], { relativeTo: this.route });
          alert("Updated successfully!");
        },
        error => {
          this.loading = false;
          alert(error);
        }
      )
  }

}
