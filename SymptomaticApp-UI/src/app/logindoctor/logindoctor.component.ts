import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './logindoctor.component.html',
  styleUrls: ['./logindoctor.component.css']
})
export class LoginDoctorComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  login(logincredential: string, password: string) {

  }
}
