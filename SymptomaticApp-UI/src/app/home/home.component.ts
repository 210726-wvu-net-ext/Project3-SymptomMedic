import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public authService: AuthService) { }

  ngOnInit(): void {
  }

  isDoctor(): boolean {
    return this.authService.currentUser.role == "doctor" ? true : false;
  }
  isClient(): boolean {
    return this.authService.currentUser.role == "client" ? true : false;
  }
}
