import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DoctorService } from '../doctor.service';
import { Appointment } from '../interfaces/appointments';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AppointmentService } from '../appointment.service';

@Component({
  selector: 'app-book-appointments',
  templateUrl: './book-appointments.component.html',
  styleUrls: ['./book-appointments.component.css']
})
export class BookAppointmentComponent implements OnInit {

  errorMsg: string | undefined;
  form: FormGroup = new FormGroup({
    
  });

  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private appointmentService: AppointmentService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      
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
    this..addDoctor(this.form.value)
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
