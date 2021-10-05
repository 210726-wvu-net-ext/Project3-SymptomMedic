import { Component, OnInit, Input} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { Doctor } from '../interfaces/doctor';
import { DoctorService } from '../doctor.service';

@Component({
  selector: 'app-doctor-profile',
  templateUrl: './doctor-profile.component.html',
  styleUrls: ['./doctor-profile.component.css']
})
export class DoctorProfileComponent implements OnInit {

  @Input() doctor?: Doctor;
  constructor(
    private docService: DoctorService,
    private route: ActivatedRoute,
    public authService: AuthService
    ) { }

    ngOnInit(): void {
      this.route.params.subscribe(routeParams => {
        this.getDoctor();
      });
    }

    getDoctor(): void {

      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.docService.getDoctor(id)
        .subscribe(
          doctor => {
          this.doctor = doctor;
          },
        );
    }

}
