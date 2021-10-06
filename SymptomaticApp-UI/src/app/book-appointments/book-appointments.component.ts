import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AuthService } from '../auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-appointments',
  templateUrl: './book-appointments.component.html',
  styleUrls: ['./book-appointments.component.css']
})
export class BookAppointmentComponent implements OnInit {

  formGroup = new FormGroup({
    FirstName: new FormControl('', [Validators.required]),
    LastName: new FormControl('', [Validators.required]),
    phonenum: new FormControl('', [Validators.required, Validators.length])
    email: new FormControl('', [Validators.required, Validators.email]),
    
  });
  invalidLogin = new Boolean;

  constructor(private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location,
    private route: ActivatedRoute,) { }

  returnUrl: any;
  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  submittion() {
    if (this.formGroup.valid) {
      const appointmentObserver = {
        next: (x: any) => {
          alert('Welcome back ' + x.email);
          this.router.navigateByUrl(this.returnUrl);
        },
        error: (err: any) => {
          console.log(err);
          alert('Unable to Login. Please check your credentials.');
        },
      };
      this.authService.loginDoctor(this.formGroup.value)
        .subscribe(appointmentObserver)
    } else {
      alert("Please enter in your information!");
    }
  }
}
