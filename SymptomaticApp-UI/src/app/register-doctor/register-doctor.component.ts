import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DoctorService } from '../doctor.service';
import { Doctor } from '../interfaces/doctor';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-register-doctor',
  templateUrl: './register-doctor.component.html',
  styleUrls: ['./register-doctor.component.css']
})
export class RegisterDoctorComponent implements OnInit {

  errorMsg: string | undefined;
  form: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    license: new FormControl(''),
    practiceName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    phoneNumber: new FormControl(''),
    doctorSpecialty: new FormControl(''),
    practiceAddress: new FormControl(''),
    practiceCity: new FormControl(''),
    practiceState: new FormControl(''),
    practiceZipcode: new FormControl(''),
    certifications: new FormControl(''),
    education: new FormControl(''),
    gender: new FormControl(''),
  });

  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private doctorService: DoctorService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      license: ['', Validators.required],
      practiceName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
      doctorSpecialty: ['', Validators.required],
      practiceAddress: ['', Validators.required],
      practiceCity: ['', Validators.required],
      practiceState: ['', Validators.required],
      practiceZipcode: ['', Validators.required],
      certifications: ['', Validators.required],
      education: ['', Validators.required],
      gender: ['', Validators.required],
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
    //this.id = this.route.snapshot.params['id'];
    this.doctorService.addDoctor(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['../login'], { relativeTo: this.route });
          alert("Register successfully!");
        },
        error => {
          this.loading = false;
          alert(error);
        }
      )
  }

}
