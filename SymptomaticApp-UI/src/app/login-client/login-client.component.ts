import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-client',
  templateUrl: './login-client.component.html',
  styleUrls: ['./login-client.component.css']
})
export class LoginClientComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  login(username: string, password: string) {//todo check if these are valid inputs

  }

}
