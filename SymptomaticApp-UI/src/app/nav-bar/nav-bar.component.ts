import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(public authService: AuthService) { }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
    alert("You have logged out. Come back soon!");
  }

  // isAdmin(): boolean {
  //   return this.authService.currentUser.role == "Doctor" ? true : false;
  // }
  // isUser(): boolean {
  //   return this.authService.currentUser.role == "Client" ? true : false;
  // }

}
