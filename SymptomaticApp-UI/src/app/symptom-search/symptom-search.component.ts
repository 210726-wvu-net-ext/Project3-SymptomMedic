import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../doctor.service';
import { Doctor } from '../interfaces/doctor';

@Component({
  selector: 'app-symptom-search',
  templateUrl: './symptom-search.component.html',
  styleUrls: ['./symptom-search.component.css']
})
export class SymptomSearchComponent implements OnInit {

  doctors: Doctor[] = [];
  searchInput: string = '';
  constructor(private doctorService: DoctorService) {}

  ngOnInit(): void {
    this.getDoctors();
  }
  getDoctors(): void{
    this.doctorService.getDoctors()
      .subscribe(doctors => this.doctors = doctors);
  }

}
