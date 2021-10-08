import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Appointment } from '../interfaces/appointments';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AppointmentService } from '../appointment.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-book-appointments',
  templateUrl: './book-appointments.component.html',
  styleUrls: ['./book-appointments.component.css']
})
export class BookAppointmentComponent implements OnInit {
  mobnumPattern = "^((\\+91-?)|0)?[0-9]{10}$";
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
    private router: Router,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      dateCreated: ['', [Validators.required]],
      clientId: ['', Validators.required],
      doctorId: ['', Validators.required],
      clientFirstName: ['', Validators.required],
      clientLastName: ['', Validators.required],
      clientContact: ['', [Validators.required, Validators.pattern(this.mobnumPattern)]],
      patientSymptoms: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
      client: ['', Validators.required],
      doctor: ['', Validators.required],
    });
  }

  get f() { return this.form.controls; }

  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }
  

  onSubmit() {
    console.log('here');
    console.log(this.form.invalid);
    console.log(this.form);
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
          this.router.navigate(['../login'], { relativeTo: this.route });
          alert("Booked successfully!");
        },
        error => {
          this.loading = false;
          alert(error);
        }
      )
  }

}
