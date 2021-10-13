import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AuthService } from '../auth.service';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login-doctor',
  templateUrl: './login-doctor.component.html',
  styleUrls: ['./login-doctor.component.css']
})
export class LoginDoctorComponent implements OnInit {

  formGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });
  invalidLogin = new Boolean;

  constructor(private authService: AuthService,
    private fb: FormBuilder,
    private _snackbar : MatSnackBar,
    private router: Router,
    private location: Location,
    private route: ActivatedRoute,) { }

  returnUrl: any;
  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  loginProcess() {
    if (this.formGroup.valid) {
      const loginObserver = {
        next: (x: any) => {
          this._snackbar.open('Welcome Back'  , x.email, {
            duration: 3000,
            verticalPosition: 'top',
            panelClass: ['blue-snackbar1','blue-snackbar2']
          })
          
          this.router.navigateByUrl(this.returnUrl);
        },
        error: (err: any) => {
          console.log(err);
          alert('Unable to Login. Please check your credentials.');
        },
      };
      this.authService.loginDoctor(this.formGroup.value)
        .subscribe(loginObserver)
    } else {
      alert("Please enter in your information!");
    }
  }
}
