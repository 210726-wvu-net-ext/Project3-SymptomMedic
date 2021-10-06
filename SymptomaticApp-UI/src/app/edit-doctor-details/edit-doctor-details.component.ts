import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../patient.service';
import { Doctor } from '../interfaces/doctor';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Insurance } from '../interfaces/insurance';
import { DoctorService } from '../doctor.service';

@Component({
  selector: 'app-edit-doctor-details',
  templateUrl: './edit-doctor-details.component.html',
  styleUrls: ['./edit-doctor-details.component.css']
})
export class EditDoctorDetailsComponent implements OnInit {

  @Input() doctor?: Doctor;
  @Input() insurances?: Insurance[];

  errorMsg: string | undefined;
  form: FormGroup = new FormGroup({

    firstName: new FormControl(''),
    lastName: new FormControl(''),
    license: new FormControl(''),
    phoneNumber: new FormControl(''),
    practiceName: new FormControl(''),
    practiceAddress: new FormControl(''),
    practiceCity: new FormControl(''),
    practiceState: new FormControl(''),
    practiceZipcode: new FormControl(''),
    certifications: new FormControl(''),
    email: new FormControl(''),
  });

  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private docService: DoctorService,
    private router: Router,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getInsurances();
    this.form = this.formBuilder.group({
      firstName: [this.doctor?.firstName, Validators.required],
      lastName: [this.doctor?.lastName, Validators.required],
      license: [this.doctor?.license, Validators.required],
      phoneNumber: [this.doctor?.phoneNumber, Validators.required],
      practiceName: [this.doctor?.practiceName, Validators.required],
      practiceAddress: [this.doctor?.practiceAddress, Validators.required],
      practiceCity: [this.doctor?.practiceCity, Validators.required],
      practiceState: [this.doctor?.practiceState, Validators.required],
      practiceZipcode: [this.doctor?.practiceZipcode, [Validators.required]],
      certifications: [this.doctor?.certifications, [Validators.required]],
      email: [this.doctor?.email, [Validators.required, Validators.email]],

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
    this.docService.updateDoctor(id, this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([`../../account/${id}`], { relativeTo: this.route });
          alert("Updated successfully!");
        },
        error => {
          this.loading = false;
          alert(error);
        }
      )
  }

  getInsurances(): void {
    this.docService.getInsurances()
      .subscribe(
        insurances => {
          console.log(insurances);
          this.insurances = insurances;
        }
      )
  }

}
