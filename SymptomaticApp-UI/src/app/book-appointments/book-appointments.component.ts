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
    dateCreated: new FormControl(''),
    clientId: new FormControl(''),
    doctorId: new FormControl(''),
    clientFirstName: new FormControl(''),
    clientLastName: new FormControl(''),
    clientContact: new FormControl(''),
    patientSymptoms: new FormControl(''),
    startTime: new FormControl(''),
    endTime: new FormControl(''),
    client: new FormControl(''),
    doctor: new FormControl(''),
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
      dateCreated: ['', [Validators.required, Validators.pattern('YYY-MM-DD HH:MM:SS.MSMSMS')]],
      clientId: ['', Validators.required],
      doctorId: ['', Validators.required],
      clientFirstName: ['', Validators.required],
      clientLastName: ['', Validators.required],
      clientContact: ['', Validators.required],
      patientSymptoms: ['', Validators.required],
      startTime: ['', [Validators.required, Validators.pattern('YYY-MM-DD HH:MM:SS.MSMSMS')]],
      endTime: ['', [Validators.required, Validators.pattern('YYY-MM-DD HH:MM:SS.MSMSMS')]],
      client: ['', Validators.required],
      doctor: ['', Validators.required],
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
    this.appointmentService.addAppointment(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['../appointment'], { relativeTo: this.route });
          alert("Booked successfully!");
        },
        error => {
          this.loading = false;
          alert(error);
        }
      )
  }

}
