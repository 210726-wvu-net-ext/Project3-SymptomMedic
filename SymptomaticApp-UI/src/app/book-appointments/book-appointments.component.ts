import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Appointment } from '../interfaces/appointments';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AppointmentService } from '../appointment.service';
import { AuthService } from '../auth.service';
import { Doctor } from '../interfaces/doctor';
import { DoctorService } from '../doctor.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-book-appointments',
  templateUrl: './book-appointments.component.html',
  styleUrls: ['./book-appointments.component.css']
})
export class BookAppointmentComponent implements OnInit {
  [x: string]: any;
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
  symptoms = this.doctor?.doctorSymptoms;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private appointmentService: AppointmentService,
    private doctorService: DoctorService,
    private router: Router,
    private datePipe: DatePipe, 
    public authService: AuthService
  ) { }
  returnurl: any;
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
    this.route.params.subscribe(routeParams => {
      this.getDoctor();
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.form.controls; }

  @Input() doctor?: Doctor;

  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }
  

  onSubmit() {
    console.log('here');
    console.log(this.form.invalid);
    console.log(this.doctor);
    this.submitted = true;
    this.form.patchValue({
      clientId: this.authService.currentUser.id,
      client: this.authService.currentUser,
      doctorId: this.doctor?.id,
      doctor: this.doctor
    });
    //save the symptoms somewhere, then null doctorsymptoms and go through the list and concatonate to a string in it
    this.symptoms = this.form.value.patientSymptoms;
    this.form.patchValue({
      patientSymptoms: "",
    });
    this.symptoms?.forEach( (value) => {
      this.form.patchValue({
        patientSymptoms: this.form.value.patientSymptoms + " " + value,
      });
    });
    this.form.value.forEach(function (val: any) {
      console.log(val);
    });
    console.log(this.form);
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
          this.router.navigate(['/']);
          alert("Booked successfully!");
        },
        error => {
          console.log(error);
          this.loading = false;
          alert(JSON.stringify(error));
        }
      )
  }

  
  getDoctor(): void {

    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.doctorService.getDoctor(id)
      .subscribe(
        doctor => {
          this.doctor = doctor;
        },
      );
  }


}
